using Movements;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using Combat;
using Managers;

namespace EnemyAI
{
    public class SnailBehaviour : Enemies
    {
        [SerializeField] bool _setStartDirection;
        [SerializeField] int _startDirection;
        float _horizontalAxisDirection;
        RbMovement _rbMovement;
        Flip _flip;
        Animator _anim;
        WallCheck _wallCheck;

        private void Awake() //Gán đối tượng
        {
            _hitDamage = GetComponent<Damage>();
            _flip = GetComponent<Flip>();
            _rbMovement = GetComponent<RbMovement>();
            _anim = GetComponent<Animator>();
            _wallCheck = GetComponent<WallCheck>();
        }
        private void Start() //Gán đối tượng 
        {
            if (!_setStartDirection) //Gán hướng
                GetRandomHorizontalAxis();
            else
                _horizontalAxisDirection = _startDirection;
        }
        void Update() //Cập nhật anim chuyển động 
        {
            
            if (_wallCheck.IsThereWall) //Kiểm tra gặp tường và xử lý
            {
                _horizontalAxisDirection = -_horizontalAxisDirection;
            }
            if (_horizontalAxisDirection != 0)
            {
                _anim.SetBool("IsMoving", true);
            }
            else
            {
                _anim.SetBool("IsMoving", false);
            }
            _flip.FlipCharacter(_horizontalAxisDirection);
        }
        private void FixedUpdate() //Di chuyển
        {
            _rbMovement.HorizontalMove(_horizontalAxisDirection);
        }
        private void OnCollisionStay2D(Collision2D collision) //Xử lý va chạm với Player
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                if(collision.GetContact(0).normal.y==-1) //Bị dẫm lên đầu
                {
                    MakeTargetJump(collision); //Xử lý hiệu ứng chết
                    _anim.SetTrigger("IsHit");
                    AddableToObjectPool deathFx = ObjectPoolManager.Instance.GetFromPool(PoolObjectsEnum.DeathEfx);
                    deathFx.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -4.3f);
                    deathFx.gameObject.SetActive(true);
                    Destroy(gameObject,0.5f);
                    
                }
                else if (collision.GetContact(0).normal.y == 1) 
                {
                    HitTarget(collision);

                }
                else
                {
                    HitTarget(collision);
                    MakeTargetJump(collision);
                }

            }

        }
        void GetRandomHorizontalAxis() //Thiết lập hướng di chuyển 1 cách ngẫu nhiên
        {
            _horizontalAxisDirection = Random.Range(1, 3);
            if (_horizontalAxisDirection == 2) _horizontalAxisDirection = -1;
        }
    }
}

