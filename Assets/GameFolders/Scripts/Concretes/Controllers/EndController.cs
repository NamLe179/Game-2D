using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class EndController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision) //Kích hoạt khi mục tiêu đi vào collider của đối tượng
        {
            // GameManager.Instance.EndGame();
            Scene currentScene = SceneManager.GetActiveScene();
            String sceneName = currentScene.name;
            if (sceneName == "Level 1(Tutorial)")
            {
                SceneManager.LoadScene("Level 2");
            }
            else if (sceneName == "Level 2")
            {
                SceneManager.LoadScene("Level 3");
            }
            else GameManager.Instance.EndGame();
            // Đoạn sau sẽ xử lý load lại về game 3d

           
        }
    }

}
