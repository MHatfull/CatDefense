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
		[SerializeField] private Placer _placer;
		[SerializeField] private Placeable _toPlace;
		[SerializeField] private Text _text;

		void Start()
		{
			_text.text = "Tower: " + _toPlace.name + "\nCost: " + _toPlace.Value;
			GetComponent<Button>().onClick.AddListener(OnClick);
		}

		void OnClick()
		{
			FindObjectOfType<TowerSelection>().RemoveSelection();
			_placer.SetCurrentTower(_toPlace);
		}
	}
}