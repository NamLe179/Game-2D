using Abstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : SingletonObject<GameManager>
    {
        public bool IsGamePaused; //Kiểm tra game tạm dừng
        public bool IsGameEnded; //Kiểm tra game end
        public event System.Action OnGameEnd; //Sự kiện thông báo
        public event System.Action OnGamePaused;
        public event System.Action OnGameUnpaused;
        private void Awake() //Đảm bảo chỉ 1 đối tượng tồn tại
        {
            SingletonThisObject(this);
        }

        public void EndGame() //Kết thúc trò chơi
        {
            IsGameEnded = true; //Gán biến
            Time.timeScale = 0f;
            OnGameEnd?.Invoke(); //Kích hoạt sự kiện
        }
        public void PauseGame() //Tạm dừng
        {
            if (IsGamePaused || IsGameEnded) return; //Kiểm tra game đã dừng/end
            IsGamePaused = true;
            Time.timeScale = 0f;
            OnGamePaused?.Invoke();

        }
        public void UnpauseGame() //Tiếp tục
        {
 
            if (!IsGamePaused || IsGameEnded) return;
            IsGamePaused = false;
            Time.timeScale = 1f;
            OnGameUnpaused?.Invoke();
        }
        
        public void RestartGame() //Chơi lại màn chơi
        {
            LoadSceneFromIndex(0); //Load lại cảnh đang chơi
        }

        public void ExitGame() //Thoát khỏi game
        {
            Debug.Log("Exit");
            Application.Quit();
        }
        public void LoadSceneFromIndex(int sceneIndex = 0) //Load cảnh theo -1,0,1
        {
            ResetGame();
            StartCoroutine(LoadSceneFromIndexAsync(sceneIndex));
        }
        public void LoadScene(int sceneIndex = 0) //Load cảnh cụ thể
        {
            ResetGame();
            StartCoroutine(LoadSceneAsync(sceneIndex));
        }
        private void ResetGame() //Reset màn chơi
        {
            
            FruitManager.Instance.ResetFruits(); //Reset số fruit
            IsGamePaused= false; 
            IsGameEnded = false;
            Time.timeScale = 1f;
            
        }
        private IEnumerator LoadSceneFromIndexAsync(int sceneIndex) //Load cảnh dạng bất đồng bộ
        {
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + sceneIndex); //Load cảnh dựa trên cảnh hiện tại + số 
        }
        private IEnumerator LoadSceneAsync(int sceneIndex) //Load cảnh bất đồng bộ
        {
            yield return SceneManager.LoadSceneAsync(sceneIndex); //Load cảnh cụ thể
        }
    }
}

