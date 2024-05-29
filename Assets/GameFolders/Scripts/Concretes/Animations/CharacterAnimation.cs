using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))] //Đảm bảo phải có thành phần Animation nếu k sẽ tự thêm
    public class CharacterAnimation : MonoBehaviour
    {
        [SerializeField] float _appearAnimPostDelay;
        Animator _anim;
        private void Awake() //Gọi đối tượng
        {
            _anim= GetComponent<Animator>();
        }
        private void OnEnable() //Kích hoạt đối tượng
        {
            AppearAnim(_appearAnimPostDelay);
        }
        public void AppearAnim(float delay) //Bắt đầu anim appear
        {
            
            _anim.SetBool("IsAppearing", true);
            StartCoroutine(AnimationFinishDelay(delay));
        }
        public void HorizontalAnim(float horizontal) //Điều chỉnh anim di chuyển
        {
            float mathfValue = Mathf.Abs(horizontal);
            if (_anim.GetFloat("moveSpeed") == mathfValue) return;
            _anim.SetFloat("moveSpeed", mathfValue);
        }
        public void JumpAnFallAnim(bool isOnGround, float yVelocity) //Điều chỉnh anim nhảy và rơi
        {
            _anim.SetBool("IsInAir", !isOnGround);
            if (!isOnGround)
            {
                _anim.SetFloat("yVelocity", yVelocity);
            }
        }
        public void TakeHitAnim(bool isInvulnerable) //Điều chỉnh anim trúng đòn
        {
           
            _anim.SetBool("TakeHit", isInvulnerable);
        }

        IEnumerator AnimationFinishDelay(float time) //Coroutine xử lý delay
        {
            yield return new WaitForSeconds(time);
            _anim.SetBool("IsAppearing", false);
        }
    }

}
