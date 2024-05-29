using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCanvas : MonoBehaviour
{
    [SerializeField] GameEndPanel _gameEndPanel; //Tham chiếu panel
    [SerializeField] GamePausedPanel _gamePausePanel;

    private void OnEnable() //Gọi khi kích hoạt, đăng kí sự kiện
    {
        GameManager.Instance.OnGameEnd += HandleOnGameEnd;
        GameManager.Instance.OnGamePaused += HandleOnGamePaused;
        GameManager.Instance.OnGameUnpaused += HandleOnGameUnpaused;
    }
    private void OnDisable() //Hủy đăng kí sự kiện tránh lỗi 
    {
        GameManager.Instance.OnGameEnd -= HandleOnGameEnd;
        GameManager.Instance.OnGamePaused -= HandleOnGamePaused;
        GameManager.Instance.OnGameUnpaused -= HandleOnGameUnpaused;
    }

    private void HandleOnGameUnpaused() //Ẩn panel
    {
        _gamePausePanel.gameObject.SetActive(false);
    }

    private void HandleOnGamePaused() //Hiện panel
    {
        _gamePausePanel.gameObject.SetActive(true);
    }

    private void HandleOnGameEnd() //Hiện panel
    {
        _gameEndPanel.gameObject.SetActive(true);
    }
}
