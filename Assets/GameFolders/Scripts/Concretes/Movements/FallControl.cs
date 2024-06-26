using Abstracts.Input;
using Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movements
{
    public class FallControl : MonoBehaviour
    {
        [SerializeField] float _fallMultiplier = 2f;
        [SerializeField] float _lowJumpMulitplier = 2f;

        Rigidbody2D _rb;
        IPlayerInput _input;
        private void Awake() //Gán đối tượng
        {
            _rb = GetComponent<Rigidbody2D>();
            _input = new PcInput();
        }
        private void Update() //Cập nhật tọa độ và trọng lực liên tục 
        {
            if (_rb.velocity.y < 0)
                _rb.velocity += Vector2.up * Physics2D.gravity.y * _fallMultiplier * Time.deltaTime;
            else if (_rb.velocity.y > 0.01 && !_input.IsJumpButton)
            {
                _rb.velocity += Vector2.up * Physics2D.gravity.y * _lowJumpMulitplier * Time.deltaTime;
            }
           
        }
    }
}
