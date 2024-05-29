using Movements;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Combat;
using Managers;

public class ChickenBehaviour : Enemies
{
    [SerializeField] float _inRangeSpeed;
   
    float _horizontalAxis;
    Vector3 _startPosition;

    private enum State
    {
        Detection,
        ChaseTarget,
        ChaseOver
    }
    State _currentState; //Trạng thái của chicken
    RbMovement _rbMovement;
    Animator _anim;
    Flip _flip;
    WallCheck _wallCheck;
    TargetDetection _targetDetection;
    GroundCheck _groundCheck;

   

    private void Awake() //Gán đối tượng
    {
        _groundCheck = GetComponent<GroundCheck>();
        _wallCheck = GetComponent<WallCheck>();
        _anim = GetComponent<Animator>();
        _flip = GetComponent<Flip>();
        _rbMovement = GetComponent<RbMovement>();
        _targetDetection = GetComponent<TargetDetection>();
        _hitDamage = GetComponent<Damage>();
    }
    private void Start() //Gán đối tượng
    {
        _startPosition = transform.position;
        
    }
    private void Update() //Cập nhật trạng thái chicken liên tục
    {
        StateControl();
        switch (_currentState) //Các trạng thái của chicken theo từng case
        {
            case State.Detection:
                Detection();
                break;
            case State.ChaseTarget:
                ChaseTarget();
                break;
            case State.ChaseOver:
                ChaseOver();
                break;
        }
 
        _flip.FlipCharacter(_horizontalAxis);

    }

    private void FixedUpdate() //Xử lý di chuyển và trạng thái khi chạm tường
    {
        _rbMovement.HorizontalMove(_horizontalAxis);
        if (_wallCheck.IsThereWall && _groundCheck.IsOnGround && _currentState != State.Detection)
        {
            _rbMovement.Jump();
        }
    }
    private void OnCollisionStay2D(Collision2D collision) //Xử lý va chạm với Player
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetContact(0).normal.y == -1) //Xử lý bị nhảy lên đầu
            {
                MakeTargetJump(collision); //Xử lý hiệu ứng chết và biến mất 
                _anim.SetTrigger("IsHit");
                AddableToObjectPool deathFx = ObjectPoolManager.Instance.GetFromPool(PoolObjectsEnum.DeathEfx);
                deathFx.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -4.3f);
                deathFx.gameObject.SetActive(true);
                
                Destroy(gameObject,0.5f); //Hủy đối tượng sau 0.5s
            }
            else if(collision.GetContact(0).normal.y == 1)
            {
                HitTarget(collision);

            }
            else
            {
                HitTarget(collision);
                MakeTargetJump(collision);
            }
        }

    }
    private void StateControl() //Điều khiển trạng thái chicken
    {
        _anim.SetFloat("moveSpeed", Mathf.Abs(_horizontalAxis));
        if (_targetDetection.IsTargetInActionRange) //Xử lý Khi Player trong khu vực hành động 
        {
            _currentState = State.ChaseTarget;
            _anim.SetBool("IsTargetInAction", true);
            _anim.SetBool("IsTargetInDetection", false);
        }
        else if(_targetDetection.IsTargetInDetectionRange) //Xử lý Khi Player trong khu vực bị phát hiện
        {
            _currentState = State.Detection;
            _anim.SetBool("IsTargetInDetection", true);
            _anim.SetBool("IsTargetInAction", false);
        }
        else //Khi Player ra khỏi khu vực bị phát hiện
        {
            _currentState = State.ChaseOver;
            _anim.SetBool("IsTargetInAction", false);
            _anim.SetBool("IsTargetInDetection", false);
            
        }

    }
    private void Detection()
    {
        _horizontalAxis = 0;
    }

    private void ChaseTarget()
    {
        if (transform.position.x < _targetDetection.TargetPos.x + 0.5 && transform.position.x > _targetDetection.TargetPos.x - 0.5)
        {
            _horizontalAxis = 0;
        }
        else if (_targetDetection.IsTargetOnLeft)
        {
            _horizontalAxis = -Mathf.Abs(_inRangeSpeed);
        }
        else if (_targetDetection.IsTargetOnRight)
        {
            _horizontalAxis = Mathf.Abs(_inRangeSpeed);
        }
    }
    private void ChaseOver()
    {
        if (transform.position.x < _startPosition.x + 0.5 && transform.position.x > _startPosition.x - 0.5)
        {
            _horizontalAxis = 0;
        }
        else if (transform.position.x < _startPosition.x)
        {
            _horizontalAxis = 1;
        }
        else if (transform.position.x > _startPosition.x)
        {
            _horizontalAxis = -1;
        }
    }
}
