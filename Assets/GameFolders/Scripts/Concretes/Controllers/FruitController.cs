using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Managers;

namespace Controllers
{
    public class FruitController : MonoBehaviour
    {
        [SerializeField] Fruits _fruitType;
        Animator _anim;
        bool _isCollected; //Xác định fruit được nhặt chưa
        private void Awake() //Gán đối tượng
        {
            _anim = GetComponent<Animator>();
        }
        private void OnTriggerEnter2D(Collider2D collision) //Kích hoạt khi đối tượng đi vào collider
        {
            if (collision.gameObject.CompareTag("Player") && !_isCollected) 
            {
                
                FruitManager.Instance.IncreaseFruitNumber(_fruitType); //Tăng fruit thu thập
                _anim.Play("Collected");
                _isCollected = true; //Đánh dấu thu thập
                Destroy(this.gameObject, 0.5f); //Hủy đối tượng sau 0.5s

            }
        }
    }
}

