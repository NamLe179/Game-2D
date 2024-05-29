using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePausedPanel : GameEndPanel //Xử lý các button trong panel tạm dừng
{
    public void PauseClick()
    {
        GameManager.Instance.UnpauseGame();
    }
    public void PlayLevel1()
    {
        GameManager.Instance.LoadScene(2);
    }
    public void SeeNextLevel()
    {
        GameManager.Instance.LoadSceneFromIndex(1);
    }
    public void MenuLevel(){
        GameManager.Instance.LoadScene(0);
    }
}
