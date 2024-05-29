using Controllers;
using Managers;
using Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Controllers
{
    public class TrambolineController : MonoBehaviour
    {
        [SerializeField] float _hitJumpForce; //Độ cao bay lên tối đa
        Rigidbody2D _rb;
        Animator _anim;
        private void Awake() //Gán đối tượng
        {
            _anim = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D collision) //Gọi khi Player nhảy lên
        {
            TargetRbAction(collision);
            PlayAnimation();
        }
        private void TargetRbAction(Collision2D collision) //Xử lý vật lý nhảy lên
        {
            _rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (_rb != null)
                _rb.AddForce(Vector2.up * _hitJumpForce);
        }
        void PlayAnimation() //Gọi hiệu ứng
        {
            _anim.SetTrigger("IsJumped");
            
        }


    }

}
