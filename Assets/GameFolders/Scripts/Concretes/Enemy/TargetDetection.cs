using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetDetection : MonoBehaviour
{
    [SerializeField] Transform _target; //Khai báo mục tiêu
    [SerializeField][Range(3, 10)] float _detectRange;
    [SerializeField][Range(3, 20)] float _actionRange;
    float _maxDistance;
   

    public Vector2 TargetPos => _target.position;
    public bool IsTargetInActionRange => _maxDistance < _actionRange;
    public bool IsTargetInDetectionRange=> _maxDistance < _detectRange;
    public bool IsTargetOnLeft => _target.position.x < transform.position.x;
    public bool IsTargetOnRight => _target.position.x > transform.position.x;


    private void Update() //Cập nhật khoảng cách giữa Player và chicken 1 cách liên tục
    {
        _maxDistance = Vector2.Distance(transform.position, _target.position);

    }
    private void OnDrawGizmos() //Vẽ đồ thị biểu diễn phạm vi detect và action
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _actionRange);
    }
}
