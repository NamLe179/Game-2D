using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFxController : MonoBehaviour
{
    AddableToObjectPool _objectPool;
    private void Awake() //Gán đối tượng
    {
        _objectPool= GetComponent<AddableToObjectPool>();
    }
    private void OnDisable() //Tắt đối tượng
    {
        ObjectPoolManager.Instance.SetPool(_objectPool);
    }
}
