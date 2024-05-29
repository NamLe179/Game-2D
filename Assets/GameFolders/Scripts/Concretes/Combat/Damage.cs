using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Combat
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] int _hitDamage;

        public int HitDamage { get => _hitDamage; }//Lấy giá trị của _hit

        public void HitTarget(Health health) //Gây dmg cho mục tiêu
        {
            health.TakeHit(this);
        }
    }

}
