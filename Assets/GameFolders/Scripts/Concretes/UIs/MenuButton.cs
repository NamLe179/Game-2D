using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene(0);
    }

    public void Quit(){
        Application.Quit();
    }
}
