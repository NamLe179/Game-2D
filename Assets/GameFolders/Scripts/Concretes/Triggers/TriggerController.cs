using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;

public class TriggerController : MonoBehaviour
{
    float _initialCooldownTime;
    private void OnTriggerEnter2D(Collider2D collision) //Gọi khi một Player đi vào vùng trigger, lưu cooldown vào biến
    {
        if (collision.gameObject.CompareTag("Player"))
            _initialCooldownTime = collision.gameObject.GetComponent<Health>().CooldownTimeAfterHit;
    }
    private void OnTriggerStay2D(Collider2D collision) //Gọi mỗi khung hình khi Player vẫn ở trong vùng trigger
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().CooldownTimeAfterHit = 0; //Đặt về 0
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //Gọi khi Player rời khỏi vùng trigger
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<Health>().CooldownTimeAfterHit = _initialCooldownTime; //Trả về giá trị ban đầu
    }
}
