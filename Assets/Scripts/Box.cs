using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatDefense
{
	public class Box : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			if (!other.gameObject.CompareTag("Enemy")) return;
			GlobalData.Health--;
			Debug.Log(GlobalData.Health);
			Destroy(other.gameObject);
			if(GlobalData.Health <= 0) {Destroy(gameObject);}
		}
	}
}