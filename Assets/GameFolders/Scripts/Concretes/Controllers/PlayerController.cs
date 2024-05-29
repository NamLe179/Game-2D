using Abstracts.Input;
using Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;
using Animations;
using Mechanics;
using Managers;
using System;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        bool _isJumped;
        float _horizontalAxis;
        IPlayerInput _input;
        CharacterAnimation _anim;
        RbMovement _rb;
        Flip _flip;
        GroundCheck _groundCheck;
        PlatformHandler _platform;
        InteractHandler _interact;
        private bool _isPaused;

        private void Awake() //Gán đối tượng
        {
            _rb= GetComponent<RbMovement>();
            _anim= GetComponent<CharacterAnimation>();
            _flip = GetComponent<Flip>();
            _groundCheck = GetComponent<GroundCheck>();
            _platform = GetComponent<PlatformHandler>();
            _interact = GetComponent<InteractHandler>();
            _input = new PcInput();
        }
        private void OnEnable() 
        {
            GameManager.Instance.OnGamePaused += HandleGamePaused;
            GameManager.Instance.OnGameUnpaused += HandleGameUnpaused;
        }
        private void OnDisable()
        {
            GameManager.Instance.OnGamePaused -= HandleGamePaused;
            GameManager.Instance.OnGameUnpaused -= HandleGameUnpaused;
        }


        private void Update() //Xử lý input và hành động Player
        {
            if (_input.IsExitButton) //Ấn ESC để tạm dừng, tiếp tục
            {
                
                if (_isPaused)
                {
                    GameManager.Instance.UnpauseGame();
                    
                }
                else
                {
                    GameManager.Instance.PauseGame();
                    
                }
            }
            if (_isPaused) return;
            _horizontalAxis = _input.HorizontalAxis;

            

            if (_input.IsJumpButtonDown && _groundCheck.IsOnGround) //Kiểm tra có ở mặt đất và k ấn jump thì được nhảy
            {
                _isJumped = true;               
            }
            if(_input.IsDownButton) //Nhảy xuống platform khi ấn xuống
                _platform.DisableCollider();
            if(_input.IsInteractButton) //Tương tác
            {
                _interact.Interact();
            }
            _anim.JumpAnFallAnim(_groundCheck.IsOnGround, _rb.VelocityY);
            _anim.HorizontalAnim(_horizontalAxis);
            _flip.FlipCharacter(_horizontalAxis);
        }
        private void FixedUpdate() //Thực hiện hành động Player
        {
            _rb.HorizontalMove(_horizontalAxis);  
            if (_isJumped )
            {
                
                _rb.Jump();
                _isJumped = false;
            }
        }
        private void HandleGameUnpaused()
        {
            _isPaused= false;
        }

        private void HandleGamePaused()
        {
            _isPaused = true;
        }

    }

}
