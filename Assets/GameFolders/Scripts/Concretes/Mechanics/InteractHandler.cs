using Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics
{
    public class InteractHandler : MonoBehaviour
    {
        LeverController _normalLever; //Tham chiếu 
        GameObject _currentInteractableObject; //Đối tượng hiện tại để tương tác
        private void OnTriggerStay2D(Collider2D collision) //Gọi khi có đối tượng với collider nằm trong trigger của Player
        {

            if (collision.gameObject.CompareTag("InteractableObject"))
            {
                _currentInteractableObject = collision.gameObject;
            }
        }
        private void OnTriggerExit2D(Collider2D collision) //Gọi khi đối tượng ra khỏi trigger
        {

            _currentInteractableObject = null;
        }

        public void Interact() //Gọi khi Player tương tác
        {
            if (_currentInteractableObject != null) //Kiểm tra đối tượng hiện tại, kiểm tra có phải lever
            {
                _normalLever = _currentInteractableObject.gameObject.GetComponent<LeverController>();
                if(_normalLever != null ) 
                    _normalLever.LeverInteraction();
                else
                    _currentInteractableObject.gameObject.GetComponent<LeverTeleportController>().LeverInteraction();
            }
            

        }
    }

}
