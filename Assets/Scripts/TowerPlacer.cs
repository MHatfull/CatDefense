using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

namespace CatDefense
{
	public class TowerPlacer : MonoBehaviour
	{
		public Tower CurrentTower { get; private set; }

		private void Update()
		{
			if(!CurrentTower) return;
			if (!Input.GetMouseButtonDown(0)) return;
			if(EventSystem.current.IsPointerOverGameObject()) return;
			if (GlobalData.Money < CurrentTower.Value) return;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (!Physics.Raycast(ray, out hit)) return;
			if (!hit.collider.gameObject.CompareTag("Ground")) return;
			Tower newTower = Instantiate(CurrentTower, hit.point, Quaternion.identity);
			GlobalData.Money -= CurrentTower.Value;
			SetCurrentTower(null);
			FindObjectOfType<TowerSelection>().SelectTower(newTower);
		}

		public void SetCurrentTower(Tower tower)
		{
			CurrentTower = tower;
		}
	}
}