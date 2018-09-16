using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatDefense
{
	public class Creep : MonoBehaviour
	{
		[SerializeField] private float _health = 100;
		[SerializeField] private int _value = 10;

		public void DealDamage(float amount)
		{
			_health -= amount;
			if (_health <= 0)
			{
				Destroy(gameObject);
				GlobalData.Money += _value;
			}
		}

	}
}