using Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abstracts;
using Combat;

public class TrunkProjectileController : Traps
{
    [SerializeField] float _maxLifeTime;
    [SerializeField] float _pushForce;
    RbMovement _rbMovement;
    AddableToObjectPool _objectPool;
    float _direction;

    public float Direction { get => _direction; set => _direction = value; }

    private void Awake() //Gán đối tượng
    {
        _hitDamage = GetComponent<Damage>();
        _rbMovement= GetComponent<RbMovement>();
        _objectPool = GetComponent<AddableToObjectPool>();
    }
    private void OnEnable() //Kích hoạt đối tượng
    {
        _direction = transform.localScale.x; //set hướng di chuyển
        StartCoroutine(SetPoolAfterDelay()); //Thiết lập vào Object Pool sau một khoảng thời gian
    }
    private void FixedUpdate() //Cập nhật liên tục di chuyển theo hướng
    {
        _rbMovement.HorizontalMove(_direction);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //Xử lý nếu là Player
        {
            HitTarget(collision); //Gây dmg
            MakeTargetJump(collision); //Bay lên khi dính dmg
            collision.attachedRigidbody.AddRelativeForce(new Vector2(_direction * _pushForce, 0)); 
            ObjectPoolManager.Instance.SetPool(_objectPool); //Đưa vào objectPool
        }
        else if(collision.gameObject.CompareTag("Box")) //Nếu là box
        {
            ObjectPoolManager.Instance.SetPool(_objectPool);
        }
    }
    IEnumerator SetPoolAfterDelay() //Đặt lại vào objectPool sau 1 khoảng thời gian
    {
        yield return new WaitForSeconds(_maxLifeTime);
        ObjectPoolManager.Instance.SetPool(_objectPool);
    }
}
