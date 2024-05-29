using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class FruitText : MonoBehaviour //Xử lý số fruit hiện lên
    {
        [SerializeField] Fruits _fruitType;
        TextMeshProUGUI _textMesh;
        private void Awake() //Gán đối tượng
        {
            _textMesh = GetComponent<TextMeshProUGUI>();
           
        }
        private void OnEnable() //Gọi khi kích hoạt, đăng kí sự kiện
        {
            FruitManager.Instance.OnFruitNumbersChanged += HandleOnFruitsNumberChanged;
        }
        private void Start() //Gọi phương thức
        {
            HandleOnFruitsNumberChanged();
        }
        private void OnDisable()
        {
            FruitManager.Instance.OnFruitNumbersChanged -= HandleOnFruitsNumberChanged;
        }

        private void HandleOnFruitsNumberChanged() //Cập nhật hiển thị 
        {
            _textMesh.SetText(FruitManager.Instance.GetFruitNumber(_fruitType).ToString());
        }
    }

}
