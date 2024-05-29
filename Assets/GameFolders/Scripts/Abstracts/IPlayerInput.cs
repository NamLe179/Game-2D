using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstracts.Input
{
    public interface IPlayerInput //Định nghĩa inrterface với thuộc tính công khai
    {
        //Các thuộc tính dạng readonly kiểm tra các button được nhấn
        float HorizontalAxis { get; }
        bool IsJumpButtonDown { get; }
        bool IsJumpButton { get; }
        bool IsDownButton { get; }
        bool IsInteractButton { get; }
        bool IsExitButton { get; }
    }
}
