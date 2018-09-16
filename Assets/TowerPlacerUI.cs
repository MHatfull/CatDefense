using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CatDefense
{
	[RequireComponent(typeof(Text))]
	public class TowerPlacerUI : MonoBehaviour
	{
		[SerializeField] private TowerPlacer _placer;
		private Text _text;

		void Start()
		{
			_text = GetComponent<Text>();
		}

		void Update()
		{
			_text.text = "Tower: " + _placer.CurrentTower.name + "\nCost: " + _placer.CurrentTower.Value;
		}
	}
}