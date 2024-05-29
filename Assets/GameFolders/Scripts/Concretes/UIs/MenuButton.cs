using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour //Button trong menu
{
    public void Play(){
        SceneManager.LoadScene(1);
    }

    public void Quit(){
        Application.Quit();
    }
}
