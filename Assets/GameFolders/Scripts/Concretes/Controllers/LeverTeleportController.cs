using Cinemachine;
using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class LeverTeleportController : MonoBehaviour
    {
         
        [SerializeField] Transform _teleportPos;
        [SerializeField] CinemachineVirtualCamera _followingCam;
        [SerializeField] float _lensValue;
        PlayerController _player;
        Animator _anim;
        Animator _playerAnim;
        bool IsLeverOn;
  
        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }
        public void LeverInteraction()
        {
                TriggerLever();
        }

        private void TriggerLever()
        {
            if (IsLeverOn)
                LeverOff();
            else
                LeverOn();

        }
        private void LeverOn() //Gạt lever mở
        {
            
            _followingCam.m_Lens.OrthographicSize = _lensValue; //Điều chỉnh size của cam
            _playerAnim.SetTrigger("IsAppear"); 
            
            IsLeverOn = true;
            _anim.SetBool("IsActive", true);
            _player.transform.position = _teleportPos.position; //Đổi vị trí của Player 

        }
        private void LeverOff()
        {
            
            IsLeverOn = false;
            _anim.SetBool("IsActive", false);

        }
        private void OnTriggerStay2D(Collider2D collision) //Lấy tham chiếu 
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                _player = collision.gameObject.GetComponent<PlayerController>();
                _playerAnim = collision.gameObject.GetComponent<Animator>();
            }
        }

    }

}
