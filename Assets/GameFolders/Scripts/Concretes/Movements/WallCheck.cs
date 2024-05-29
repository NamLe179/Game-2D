using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movements
{
    public class WallCheck : MonoBehaviour //Kiểm tra chạm tường
    {
        [SerializeField] Transform[] _rayOrigins;
        [SerializeField] float _maxRayLength;
        [SerializeField] LayerMask _layerMask;
        bool _isThereWall;
        RbMovement _rbMovement;
        public bool IsThereWall { get => _isThereWall; }
        private void Awake() //Gán đối tượng
        {
            _rbMovement = GetComponent<RbMovement>();
        }
        private void Update() //Cập nhật vị trí liên tục
        {
            foreach(Transform rayOrigin in _rayOrigins)
            {
                CheckWalls(rayOrigin);
                if (_isThereWall) break;
            }     
        }
        void CheckWalls(Transform rayOrigin) //Kiểm tra chạm tường chưa
        {
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, Vector2.right * _rbMovement.HorizontalDirection, _maxRayLength, _layerMask);
            Debug.DrawRay(rayOrigin.position, Vector2.right * _rbMovement.HorizontalDirection * _maxRayLength, Color.red);
            if (hit.collider != null)
            {
                _isThereWall = true;
            }
            else
                _isThereWall = false;
        }
    }
}

