using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlatformController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 2f;
    [SerializeField] Vector2 _direction;
    [SerializeField] float _length;
    [SerializeField] bool _moveAtStart;
    Vector3 _offset;
    float sinWave;

    float _currentTime;

    private void FixedUpdate()   //Cập nhật vị trí platform liên tục
    {

        sinWave = Mathf.Sin(Time.timeSinceLevelLoad* _moveSpeed);
        if (!_moveAtStart) return;
        
        _offset = _direction.normalized * _length * sinWave;
        transform.position += _offset * Time.deltaTime;
        //Platform đi dạng hình sin để tạo độ mượt

    }
    private void OnCollisionEnter2D(Collision2D collision) //Kích hoạt khi có va chạm với đối tượng
    {
        if(collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform); //Gán Player thành con để khi platform di chuyển Player di chuyển theo
        }
    }
    private void OnCollisionStay2D(Collision2D collision) //Kích hoạt khi đang va chạm
    {
        if (collision.collider.CompareTag("Player") && !_moveAtStart)
        {
                _moveAtStart = true; //Đối tượng là Player và chưa di chuyển thì sẽ di chuyển
        }
    }
    private void OnCollisionExit2D(Collision2D collision) //Kích hoạt khi đối tượng k va chạm với Platform
    {
        if (collision.collider.CompareTag("Player"))
            collision.collider.transform.SetParent(null); //Gỡ Player ra khỏi parent-child
    }
    
}
