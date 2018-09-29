using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatDefense
{
    public abstract class TowerWeapon : MonoBehaviour
    {       
        public abstract void Fire(GameObject target);
    }
}