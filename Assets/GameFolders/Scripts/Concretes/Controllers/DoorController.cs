using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class DoorController : MonoBehaviour
    {
        [SerializeField] Fruits _doorFruitType;
        [Range(0, 4)][SerializeField] int _doorFruitNumber;
        Animator _anim;

        public Fruits DoorFruitType { get => _doorFruitType; }
        public int DoorFruitNumber { get => _doorFruitNumber; set => _doorFruitNumber = value; }

        private void Awake() //Gán đối tượng
        {
            _anim = GetComponent<Animator>();
        }
        public void OpenDoor() //Mở cửa
        {
            
            _anim.SetBool("IsOpen", true);
        }
        public void CloseDoor() //Đóng cửa
        {
            _anim.SetBool("IsOpen", false);
        }
    }

}
