using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abstracts;
using Combat;

namespace Controllers
{
    public class SpikesController : Traps 
    {
        private void Awake() //Gán đối tượng
        {
            _hitDamage = GetComponent<Damage>();
        }

        private void OnTriggerEnter2D(Collider2D collision) //Gọi khi Player dẫm/nhảy vào
        {
            HitTarget(collision);
            MakeTargetJump(collision);
        }


    }
}

