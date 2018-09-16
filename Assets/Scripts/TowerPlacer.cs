using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace CatDefense
{
	public class TowerPlacer : MonoBehaviour
	{
		[SerializeField] private Tower[] _towers;
		
		private Tower _tower;
		public Tower CurrentTower
		{
			get { return _tower; }
		}

		private void Awake()
		{
			_tower = _towers[0];
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				_tower = _towers[0];
			}

			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				_tower = _towers[1];
			}
			if (!Input.GetMouseButtonDown(0)) return;
			if (GlobalData.Money < _tower.Value) return;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (!Physics.Raycast(ray, out hit)) return;
			if (!hit.collider.gameObject.CompareTag("Ground")) return;
			Instantiate(_tower, hit.point, Quaternion.identity);
			GlobalData.Money -= _tower.Value;
			Debug.Log(GlobalData.Money);
		}
	}
}