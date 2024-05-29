using Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIs
{
    public class FilledHeartsImages : MonoBehaviour
    {
        [SerializeField] Health _playerHealth;
        Image[] _filledHearts;

        private void Awake() //Gán đối tượng
        {
            _filledHearts = GetComponentsInChildren<Image>();
        }
        private void OnEnable() //Gọi khi kích hoạt, đăng kí sự kiện
        {
            _playerHealth.OnHealthChanged += HandleHealthChanged;
            _playerHealth.OnDead += HandleOnDead;
        }
        private void Start()
        {
            HandleHealthChanged();
        }

        private void HandleOnDead() //Xử lý sau khi chết - hs lại
        {
            for(int i=0; i< _playerHealth.MaxHealth;i++)
            {
                _filledHearts[i].gameObject.SetActive(true);
            }
        }

        private void HandleHealthChanged() //Giảm máu 
        {
            if (_filledHearts.Length > _playerHealth.CurrentHealth)
            {
                int deleteCount = _filledHearts.Length - _playerHealth.CurrentHealth;
                for (int i = 1; i < deleteCount + 1; i++)
                {
                    _filledHearts[_filledHearts.Length - i].gameObject.SetActive(false);
                }
            }
        }
    }

}