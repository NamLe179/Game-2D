using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abstracts;
using Combat;

public class SawController : Traps 
{
    [SerializeField] Transform[] _patrolPoints; //Các vị trí để cưa di chuyển
    [SerializeField] float _moveSpeed; //Tốc độ
    [SerializeField] Transform SawPositionsParent; //Lớp cha để saw tham chiếu
    Vector2[] _patrolPositions; //Tọa độ của vị trí
    Vector2 _movePos;
    int _patrolPointIndex = 0;
    Vector3 _currentPointPos;
    Vector3 _startPointPos;
    
    private void Awake() //Gán đối tượng
    {
        _hitDamage = GetComponent<Damage>();
    }
    private void Start() //Gán đối tượng khi bắt đầu
    {
        _currentPointPos = _patrolPoints[0].position;
        _startPointPos = transform.position;
        _patrolPositions= new Vector2[_patrolPoints.Length];
        foreach(Transform position in _patrolPoints)
        {
            position.SetParent(SawPositionsParent);
        }
        
    }
    private void Update() //Cập nhật vị trí liên tục
    {
        _movePos = _currentPointPos - transform.position;
        transform.Translate(_movePos.normalized * _moveSpeed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position,_currentPointPos)<= 1f)
        {
            NextPoint();
        }
        
    }

    private void NextPoint() //Chuyển vị trí sau khi saw đi qua 
    {
        _patrolPointIndex++;
        if(_patrolPointIndex == _patrolPoints.Length)
        { 
            _currentPointPos = _startPointPos;
            return; 
        }
        else if(_patrolPointIndex > _patrolPoints.Length)
        {
            _patrolPointIndex = 0;
        }
        _currentPointPos = _patrolPoints[_patrolPointIndex].position;
    }

    private void OnTriggerEnter2D(Collider2D collision) //Gọi khi player chạm saw
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HitTarget(collision);
            MakeTargetJump(collision);
        }
    }
}
