using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CatDefense
{
	[RequireComponent(typeof(Button))]
	public class TowerButton : MonoBehaviour
	{
		[SerializeField] private TowerPlacer _placer;
		[SerializeField] private Tower _tower;
		[SerializeField] private Text _text;

		void Start()
		{
			_text.text = "Tower: " + _tower.name + "\nCost: " + _tower.Value;
			GetComponent<Button>().onClick.AddListener(OnClick);
		}

		void OnClick()
		{
			_placer.SetCurrentTower(_tower);
		}
	}
}