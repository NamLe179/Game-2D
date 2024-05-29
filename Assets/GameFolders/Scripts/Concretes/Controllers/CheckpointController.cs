using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    bool _isChecked;

    Animator _anim;

    public bool IsChecked { get => _isChecked; }

    private void Awake() //Gán đối tượng
    {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision) //Kích hoạt đôí tượng khi mục tiêu đi vào collider của đối tượng
    {

        if (!_isChecked && collision.gameObject.CompareTag("Player"))
        {
            _anim.SetBool("FlagOut", true);
           
            _isChecked = true;
            
        }
    }
}
