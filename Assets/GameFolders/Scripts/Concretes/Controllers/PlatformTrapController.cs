using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class PlatformTrapController : MonoBehaviour
    {
        Rigidbody2D _rb;
        private void Awake() //Gán đối tượng
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        private void OnCollisionExit2D(Collision2D collision) //Kích hoạt khi đối tượng khác rời khỏi platform
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _rb.isKinematic = false; //Cho phép tương tác vật lý
                _rb.gravityScale = 2f; //Gán trọng lực
                Destroy(this.gameObject, 1.5f); //Hủy đối tượng sau 1.5s
            }
        }
    }

}
