using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatDefence
{
	public class TowerPlacer : MonoBehaviour
	{
		[SerializeField] private GameObject tower;
		private void Update()
		{
			if (!Input.GetMouseButtonDown(0)) return;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (!Physics.Raycast(ray, out hit)) return;
			if (hit.collider.gameObject.CompareTag("Ground"))
			{
				Instantiate(tower, hit.point, Quaternion.identity);
			}
		}
	}
}