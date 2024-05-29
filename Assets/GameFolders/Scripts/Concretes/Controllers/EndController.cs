using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class EndController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision) //Kích hoạt khi mục tiêu đi vào collider của đối tượng
        {
            GameManager.Instance.EndGame();
           
        }
    }

}
