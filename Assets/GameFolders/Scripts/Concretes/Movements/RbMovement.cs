using Abstracts.Input;
using Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

namespace Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RbMovement: MonoBehaviour //Di chuyển vật lý
    {
        [SerializeField] float _jumpForce=10f; //Lực nhảy
        [SerializeField] float _horizontalSpeed=10f; //Tốc chạy
        private float _horizontalDirection; //Hướng
        Rigidbody2D _rb;
        public float VelocityY => _rb.velocity.y;
        public float HorizontalDirection { get => _horizontalDirection; set => _horizontalDirection = value; }
        private void Awake() //Gán đối tượng
        {
            _rb= GetComponent<Rigidbody2D>();
        }
        public void Jump() //Vật lý khi nhảy
        {
            _rb.velocity = Vector2.up * _jumpForce;
            // _rb.AddForce(Vector2.up * _jumpForce);
        }
        public void HorizontalMove(float direction) //Vật lý khi di chuyển
        {
            HorizontalDirection = Mathf.Sign(direction);
            //_rb.position += Vector2.right * direction * _horizontalSpeed * Time.deltaTime;
            _rb.velocity = new Vector2(direction * _horizontalSpeed, _rb.velocity.y);
        }
    }
}
