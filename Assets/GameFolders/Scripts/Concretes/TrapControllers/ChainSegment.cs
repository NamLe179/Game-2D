using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSegment : MonoBehaviour //Bộ phận của xích
{
    [SerializeField] float _maxTime; 
    [SerializeField] float _zRotation;
    float _currentTime;

    private void Start() //Bắt đầu gán vị trí chuyển động
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + _zRotation);
    }
    private void Update() //cập nhật thời gian và vị trí liên tục
    {
        _currentTime += Time.deltaTime;
        if (_currentTime>_maxTime)
        {          
            if(transform.rotation.z>0)
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z - _zRotation);
            else
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + _zRotation);
            _currentTime = 0;
        }
    }
}
