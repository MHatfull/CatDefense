using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatDefense
{
    public abstract class TowerWeapon : MonoBehaviour
    {
        [SerializeField] private RangeRing _rangeRing;
        
        public abstract void Fire(GameObject target);

        public void DisplayRange(float r, bool on)
        {
            _rangeRing.Enable(on);
            _rangeRing.SetRange(r);
        }
    }
}