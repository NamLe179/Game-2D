using Abstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class FruitManager : SingletonObject<FruitManager>
    {
        Dictionary<Fruits, int> _fruits = new Dictionary<Fruits, int>(); //Khai báo fruit cùng số lượng
        public event System.Action OnFruitNumbersChanged; //Sự kiện đổi số lượng fruit
        private void Awake() //Gán đối tượng về trạng thái ban đầu và đảm bảo chỉ 1 FruitManage tồn tại
        {
            SingletonThisObject(this);
            ResetFruits();
        }
        private void Start() //Xử lý sự kiện 
        {
            OnFruitNumbersChanged?.Invoke(); //Kích hoạt sự kiện
        }
        public void ResetFruits() //Đưa số lượng về 0
        {
            _fruits.Clear();
            _fruits.Add(Fruits.Banana, 0);
            _fruits.Add(Fruits.Pineapple, 0);
            _fruits.Add(Fruits.Melon, 0);
            OnFruitNumbersChanged?.Invoke();
        }
        public int GetFruitNumber(Fruits fruit) //Lấy số lượng fruit từ từ điển
        {
            return _fruits[fruit];
        }
        public bool AreThereEnoughFruit(Fruits fruit, int limit) //Kiểm tra số lượng đến tối đa
        {
            if (_fruits[fruit] >= limit)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void IncreaseFruitNumber(Fruits fruit) //Tăng số lượng nếu nhặt được
        {
            _fruits[fruit]++;
            OnFruitNumbersChanged?.Invoke();
        }
        public void DecreaseFruitNumber(Fruits fruit, int number) //Giảm số lượng sau khi gạt lever
        {
            _fruits[fruit] = _fruits[fruit] - number;
            if (_fruits[fruit] < 0)
            {
                _fruits[fruit] = 0;
            }
            OnFruitNumbersChanged?.Invoke();
        }
        private void Reset() 
        {
            
        }
        //private void Update()
        //{
        //    //Delete update
        //    Debug.Log("-------------------------------");
        //    Debug.Log("-------------------------------");
        //    Debug.Log("-------------------------------");
        //    Debug.Log("-------------------------------");
        //    Debug.Log("-------------------------------");
        //    Debug.Log("Melon " + _fruits[Fruits.Melon]);
        //    Debug.Log("Banana" + _fruits[Fruits.Banana]);
        //    Debug.Log("Pineapple" + _fruits[Fruits.Pineapple]);

        //}
    }

}
