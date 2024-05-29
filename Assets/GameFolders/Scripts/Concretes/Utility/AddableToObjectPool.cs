using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddableToObjectPool : MonoBehaviour //Quản lý các đối tượng có thể thêm vào object pool
{
    [SerializeField] PoolObjectsEnum _objectType;

    public PoolObjectsEnum ObjectType => _objectType;

}
