using System;
using UnityEngine;
using UnityEngine.UI;

namespace CatDefense
{
	[RequireComponent(typeof(Button))]
	public class UpgradeButton : MonoBehaviour
	{
		private Button _mainButton;
		[SerializeField] private GameObject _buttonContainer;
		[SerializeField] private Button[] _upgrades;
		public bool interactable
		{
			get { return _mainButton.interactable; }
			set { _mainButton.interactable = value; }
		}

		private void Start()
		{
			_mainButton = GetComponent<Button>();
			_mainButton.onClick.AddListener(ToggleRollout);
			foreach (Button upgrade in _upgrades)
			{
				upgrade.onClick.AddListener( delegate
				{
					ToggleRollout();
					if (OnUpgradeSelected != null) OnUpgradeSelected();
				});
			}
		}

		private void ToggleRollout()
		{
			_buttonContainer.SetActive(!_buttonContainer.activeSelf);
		}

		public event Action OnUpgradeSelected;
	}
}