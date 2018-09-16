using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatDefense
{
    public class Bullet : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Creep>().DealDamage(10);
            }
            Destroy(gameObject);
        }
    }
}