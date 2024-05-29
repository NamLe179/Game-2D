using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movements
{
    public class PlatformHandler : MonoBehaviour //Xử lý platform
    {
        private GameObject _currentPlatform;
        private BoxCollider2D _playerCollider;
        private BoxCollider2D _currentPlatformCollider;
        private void Awake() //Gán đối tượng
        {
            _playerCollider = GetComponent<BoxCollider2D>();
        }
        private void OnCollisionStay2D(Collision2D collision) //Gọi đối tượng khi collider nằm trong trigger của player
        {
            if (collision.gameObject.CompareTag("OneWayPlatform"))
                _currentPlatform = collision.gameObject;
        }
        private void OnCollisionExit2D(Collision2D collision) //Ra khỏi collider
        {
            _currentPlatform = null;
        }
        public void DisableCollider() //Hủy collider
        {
            if (_currentPlatform != null)
                StartCoroutine(DisableColliderCoroutine());
        }

        private IEnumerator DisableColliderCoroutine() 
        {
            _currentPlatformCollider = _currentPlatform.GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(_playerCollider, _currentPlatformCollider);
            yield return new WaitForSeconds(0.25f);
            Physics2D.IgnoreCollision(_playerCollider, _currentPlatformCollider, false);

        }
    }
}

