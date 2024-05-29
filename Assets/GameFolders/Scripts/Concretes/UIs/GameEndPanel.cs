using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndPanel : MonoBehaviour //Xử lý các button trong panel kết thúc
{
    public void TutorialClick()
    {
        GameManager.Instance.LoadScene(1);
    }
    public void PlayAgainClick()
    {
        GameManager.Instance.RestartGame();
    }
    public void ExitClick()
    {
        GameManager.Instance.ExitGame();
    }
    public void MenuClick(){
        GameManager.Instance.LoadScene(0);
    }
    public void NextLevelClick()
    {
        GameManager.Instance.LoadSceneFromIndex(1);
    }
    public void PreviousLevelClick()
    {
        GameManager.Instance.LoadSceneFromIndex(-1);
    }
}


