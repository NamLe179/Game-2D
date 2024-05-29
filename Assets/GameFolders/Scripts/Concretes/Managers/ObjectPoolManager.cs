using Abstracts;
using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : SingletonObject<ObjectPoolManager> //Quản lý tái sử dụng đối tượng
{
    [SerializeField] AddableToObjectPool[] _prefabs; //Mảng được quản lý
    [SerializeField] int _queueLength; //Độ dài queue
    Dictionary<PoolObjectsEnum, Queue<AddableToObjectPool>> _objectsDictionary = new Dictionary<PoolObjectsEnum, Queue<AddableToObjectPool>>(); //Từ điển lưu trữ hàng đợi

    private void Awake() //Đảm bảo chỉ 1 tồn tại
    {
        SingletonThisObject(this);
    }
    private void Start() //Gọi phương thức khi băt đầu
    {
        InitalizePool();
    }
    private void InitalizePool() //khởi tạo hàng đợi đối tượng cho mỗi prefab
    {
        for (int i = 0; i < _prefabs.Length; i++)
        {
            Queue<AddableToObjectPool> objectQueue = new Queue<AddableToObjectPool>();
            for (int j = 0; j < _queueLength; j++)
            {
                AddableToObjectPool newObject = Instantiate(_prefabs[i]);
                newObject.gameObject.SetActive(false);
                newObject.transform.parent = this.transform;
                objectQueue.Enqueue(newObject);
            }
            _objectsDictionary.Add((PoolObjectsEnum)i, objectQueue);
        }
    }
    public void SetPool(AddableToObjectPool newObj) //Thêm đối tượng vào pool
    {
        newObj.gameObject.SetActive(false); //Tắt đối tượng
        newObj.transform.parent = this.transform; //Đặt làm con của Manager này
        Queue<AddableToObjectPool> gameObjectsQueue = _objectsDictionary[newObj.ObjectType]; //Thêm vào queue tương ứng
        gameObjectsQueue.Enqueue(newObj);
    }
    public AddableToObjectPool GetFromPool(PoolObjectsEnum newObjectType) //Lấy đối tượng từ pool
    {
        Queue<AddableToObjectPool> gameObjectsQueue = _objectsDictionary[newObjectType];
        if (gameObjectsQueue.Count == 0) //Hàng đợi rỗng thì tạo đối tượng từ prefab tương ứng và thêm vào hàng đợi
        {
            AddableToObjectPool newObj = Instantiate(_prefabs[(int)newObjectType]);
            gameObjectsQueue.Enqueue(newObj);
        }
        return gameObjectsQueue.Dequeue();
    }
}
