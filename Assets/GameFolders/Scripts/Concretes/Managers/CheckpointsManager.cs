using Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Combat;
using Managers;

public class CheckpointsManager : MonoBehaviour
{
    [SerializeField] Health _playerHealth; //Lấy máu từ Player
    CheckpointController[] _checkpoints;
    StartpointController _startpoint;
    private void Awake() //Gán đối tượng
    {
        _startpoint = GetComponentInChildren<StartpointController>();
        _checkpoints = GetComponentsInChildren<CheckpointController>();
    }
    private void OnEnable() 
    {
        _playerHealth.OnDead += HandleOnDead;
    }
    public void HandleOnDead() //Xử lý biến về checkpoint gần nhất nếu chết
    {
        
        if(_checkpoints.LastOrDefault(x => x.IsChecked) == null)
            _playerHealth.transform.position = _startpoint.transform.position;
        else
        {
            _playerHealth.transform.position = _checkpoints.LastOrDefault(x=>x.IsChecked).transform.position;
        }  
    }

}
