using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstracts
{
    public class SingletonObject<T> : MonoBehaviour
    {
        public static T Instance { get; private set; } //thuộc tính tĩnh có thể gán giá trị trong lớp và truy cập từ ngoài
        protected void SingletonThisObject(T entity) //Gán gái trị cho instance đảm bảo chỉ một entity tồn tại
        {
            if (Instance == null)
            {
                Instance = entity;
                DontDestroyOnLoad(this.gameObject); //Đảm bảo gameObject chứa entity k bị hủy khi tải cảnh mới
            }
            else
            {
                Destroy(this.gameObject); //Hủy gameObject để chỉ có 1 entity duy nhất tồn tại trong game
            }
        }
    }

}
