using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Controllers
{
    public class LeverController : MonoBehaviour
    {
        [SerializeField] DoorController _door;
        [SerializeField] GameObject _checkMark;
        [SerializeField] GameObject _leverFruits;
        Animator _anim;
        bool IsLeverOn; //Trạng thái lever
        bool CanLeverWork; //Xác định lever có thể gạt k
        private void Awake() //Gán đối tượng
        {
            _anim = GetComponent<Animator>();
        }
        public void LeverInteraction() //Xử lý tương tác với lever
        {
            if (!CanLeverWork)
            {
                TryActivateLever();
                
            }
            else
                TriggerLever();
        }
        private void TryActivateLever() //Kiểm tra điều kiện để kích hoạt lever
        {
            if (CheckConditions())
            {
                CanLeverWork = true; //Gán giá trị
                FruitManager.Instance.DecreaseFruitNumber(_door.DoorFruitType, _door.DoorFruitNumber); //Giảm fruit
                TriggerLever();
                _checkMark.SetActive(true);
                _leverFruits.SetActive(false);
            }
            
        }
        private void TriggerLever() //Chuyển trạng thái lever
        {
            
            if (IsLeverOn)
                LeverOff();
            else
                LeverOn();

        }
        private void LeverOn() //Gạt lever mở
        {
            IsLeverOn = true;
            _anim.SetBool("IsActive", true);
            _door.OpenDoor();
        }
        private void LeverOff() //Gạt lever đóng
        {
            IsLeverOn = false;
            _anim.SetBool("IsActive", false);
            _door.CloseDoor();
        }
        private bool CheckConditions() //Kiểm tra có đủ điều kiện để gạt lever k
        {
            return FruitManager.Instance.AreThereEnoughFruit(_door.DoorFruitType, _door.DoorFruitNumber);
        }
    }

}
