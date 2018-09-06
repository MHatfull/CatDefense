using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatDefence
{
    public class Bullet : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }
}