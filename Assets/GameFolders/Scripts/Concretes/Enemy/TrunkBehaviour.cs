using Movements;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Combat;
using Managers;

public class TrunkBehaviour : Enemies
{
    [SerializeField] float _maxChangeDirectionTime; //Thời gian giữa 2 lần đổi hướng
    [SerializeField] float _maxAttackTime; //Thời gian giữa 2 lần bắn
    [SerializeField] Transform _projectileSpawnTransform; //Vị trí đạn xuất hiện
    [SerializeField] Transform _projectiles;
    [SerializeField] bool _dontChangeDirection; //Kiểm tra đổi hướng
    float _horizontalDirection;
    float _currentTime;
    bool _isPlayerFound; //Kiểm tra tìm thấy Player
    Flip _flip;
    WallCheck _playerCheck;
    RbMovement _rbMovement;
    Animator _anim;
    
    private void Awake() //Gán đối tượng
    {
        _anim = GetComponent<Animator>();
        _hitDamage = GetComponent<Damage>();
        _playerCheck = GetComponent<WallCheck>();
        _rbMovement= GetComponent<RbMovement>();
        _flip = GetComponent<Flip>();
    }
    private void Start() //Gán đối tượng
    { 
        
        GetRandomHorizontalAxis();
    }
    private void Update() //Cập nhật tấn công Player
    {
        if (!_isPlayerFound) 
            ChangeDirectionWithTime(); //Xoay liên tục nếu k thấy Player
        else
            SendProjectilesWithTime(); //Bắn

        PlayerCheck();
        _flip.FlipCharacter(_horizontalDirection);
       _rbMovement.HorizontalDirection= _horizontalDirection;
        
    }
    void GetRandomHorizontalAxis() //Thiết lập hướng di chuyển ngẫu nhiên nếu đổi hướng
    {
        if (_dontChangeDirection) { _horizontalDirection = 1; return; } 
        _horizontalDirection = Random.Range(1, 3);
        if (_horizontalDirection == 2) _horizontalDirection = -1;
    }
    void ChangeDirectionWithTime() //Thay đổi hướng di chuyển sau 1 thời gian
    {
        if (_dontChangeDirection) return;
        _currentTime += Time.deltaTime;
        if (_currentTime > _maxChangeDirectionTime)
        {
            _horizontalDirection = -_horizontalDirection;
            _currentTime = 0;
        }
    }
    void SendProjectilesWithTime() //Hiệu ứng sinh và bay của đạn
    {
        
        _currentTime += Time.deltaTime;
        if (_currentTime > _maxAttackTime)
        {
            _anim.SetTrigger("IsAttack");
            AddableToObjectPool projectile = ObjectPoolManager.Instance.GetFromPool(PoolObjectsEnum.TrunkBullet);
            projectile.transform.SetParent(_projectiles);
            projectile.transform.position = _projectileSpawnTransform.position;
            projectile.transform.localScale = new Vector2(_horizontalDirection, 1);
            projectile.gameObject.SetActive(true);
            _currentTime = 0;
        }
    }
    private void PlayerCheck() //Kiểm tra Player có trong phạm vi tấn công
    {
        if (_playerCheck.IsThereWall)
        {
            _isPlayerFound = true;
            
        }
        else
        {
            _isPlayerFound = false;
           
        }
    }
    private void OnCollisionStay2D(Collision2D collision) //Xử lý va chạm với Player
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetContact(0).normal.y == -1) //Nếu bị diệt
            {
                MakeTargetJump(collision);
                _anim.SetTrigger("IsHit");
                AddableToObjectPool deathFx = ObjectPoolManager.Instance.GetFromPool(PoolObjectsEnum.DeathEfx);
                deathFx.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -4.3f);
                deathFx.gameObject.SetActive(true);
                Destroy(gameObject,0.5f);
                
            }
            else //Bắn trúng Player
            {
                HitTarget(collision);
                MakeTargetJump(collision);
            }
        }
    }
}

