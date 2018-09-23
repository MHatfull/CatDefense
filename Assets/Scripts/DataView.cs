using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CatDefense
{
	[RequireComponent(typeof(Text))]
	public class DataView : MonoBehaviour
	{
		private Text _text;

		private void Awake()
		{
			_text = GetComponent<Text>();
		}

		private void Update()
		{
			_text.text = GlobalData.Health + " health, " + GlobalData.Money + " money";
		}
	}
}