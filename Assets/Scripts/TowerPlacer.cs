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
		private Tower _tower;
		
		public Tower CurrentTower
		{
			get { return _tower; }
		}

		private void Update()
		{
			if(!_tower) return;
			if (!Input.GetMouseButtonDown(0)) return;
			if(EventSystem.current.IsPointerOverGameObject()) return;
			if (GlobalData.Money < _tower.Value) return;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (!Physics.Raycast(ray, out hit)) return;
			if (!hit.collider.gameObject.CompareTag("Ground")) return;
			Instantiate(_tower, hit.point, Quaternion.identity);
			GlobalData.Money -= _tower.Value;
		}

		public void SetCurrentTower(Tower tower)
		{
			_tower = tower;
		}
	}
}