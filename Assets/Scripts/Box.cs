using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatDefence
{
	public class Box : MonoBehaviour
	{
		private static int _health = 30;

		private void OnTriggerEnter(Collider other)
		{
			if (!other.gameObject.CompareTag("Enemy")) return;
			_health--;
			Debug.Log(_health);
			Destroy(other.gameObject);
		}
	}
}