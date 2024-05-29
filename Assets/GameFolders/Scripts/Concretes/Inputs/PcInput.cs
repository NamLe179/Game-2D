using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abstracts.Input;
namespace Inputs
{
    public class PcInput : IPlayerInput //Lấy input từ bàn phím và gán cho các biến
    {
        public float HorizontalAxis => Input.GetAxis("Horizontal"); //Di chuyển
        public bool IsJumpButtonDown => Input.GetButtonDown("Jump");   
        public bool IsJumpButton => Input.GetButton("Jump"); //Nhảy
        public bool IsDownButton => Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow); //Ấn xuống để rơi từ platform
        public bool IsInteractButton => Input.GetKeyDown(KeyCode.E); //Tương tác
        public bool IsExitButton => Input.GetKeyDown(KeyCode.Escape); //Ấn ESC
    }

}
