using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;
public class Enemies : MonoBehaviour
{
    [SerializeField] float _hitJumpForce;
    protected Damage _hitDamage;
    Rigidbody2D _rb;
    Health _targetHealth;
    protected void HitTarget(Collision2D collision) //Xử lý khi đối tượng va chạm với mục tiêu
    {
        _targetHealth = collision.gameObject.GetComponent<Health>();
        if (_targetHealth != null)
            _hitDamage.HitTarget(_targetHealth);
    }
    // Update is called once per frame
    protected void MakeTargetJump(Collision2D collision) //Xử lý đối tượng sẽ bay lên 1 đoạn sau khi bị va chạm
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        _rb = collision.rigidbody;
        _rb.velocity = Vector2.zero; //Đặt lại vận tốc
        _rb.AddForce(Vector2.up * _hitJumpForce);
    }
}
