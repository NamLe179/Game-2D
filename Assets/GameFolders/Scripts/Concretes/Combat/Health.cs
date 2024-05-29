using Animations;
using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int _maxHealth;
        [SerializeField] bool _IsCooldownAfterHit;
        [SerializeField] float _cooldownTimeAfterHit;
        bool _isInvulnerable;
        int _currentHealth;
        public bool IsDead => _currentHealth <= 0; //Trả về true nếu máu về 0

        public int MaxHealth { get => _maxHealth; }
        public int CurrentHealth { get => _currentHealth;  }
        public float CooldownTimeAfterHit { get => _cooldownTimeAfterHit; set => _cooldownTimeAfterHit = value; }

        public event System.Action OnDead; //Kích hoạt khi đối tượng chết
        public event System.Action OnHealthChanged; //Kích hoạt khi máu tăng/giảm
        CharacterAnimation _anim;

        private void Awake() //Gán đối tượng
        {
            _anim = GetComponent<CharacterAnimation>();
            _currentHealth = _maxHealth;
        }
        private void OnEnable() //Kích hoạt sự kiện
        {
            OnHealthChanged?.Invoke();
            OnDead += HandleOnDead;
        }

        private void HandleOnDead() //Khởi tạo lại máu và anim appear
        {
            _currentHealth = _maxHealth;
            _anim.AppearAnim(0.4f);
        }
        public void TakeHit(Damage damage) //Xử lý đối tượng bị đánh trúng
        {
            if (_isInvulnerable) //Không thể mất máu thì dừng
            {
                return;
            }
    
            _currentHealth -= damage.HitDamage;
            OnHealthChanged?.Invoke();
            StartCoroutine(HitCooldown());
            if (IsDead)
                OnDead?.Invoke();
        }
        IEnumerator HitCooldown() //Coroutine xử lý thời gian k thể mất máu giữa 2 lần hit 
        {
            _isInvulnerable = true;
            _anim.TakeHitAnim(true);
            yield return new WaitForSeconds(_cooldownTimeAfterHit);
            _isInvulnerable = false;
            _anim.TakeHitAnim(false);

        }
    }
}

