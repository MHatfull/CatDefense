using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace CatDefense
{
	[RequireComponent(typeof(Button))]
	public class UpgradeButton : MonoBehaviour
	{
		private Button _mainButton;

		[SerializeField] private TowerSelection _selection;
		[SerializeField] private GameObject _buttonContainer;
		[SerializeField] private Button _upgradeButtonPrefab;

		private readonly List<Button> _buttons = new List<Button>();
		
		public bool interactable
		{
			set { _mainButton.interactable = value; }
		}

		private void Start()
		{
			_mainButton = GetComponent<Button>();
			_mainButton.onClick.AddListener(ToggleRollout);
		}

		private void ToggleRollout()
		{
			_buttonContainer.SetActive(!_buttonContainer.activeSelf);
			if (_buttons.Any()) return;
			foreach (Upgrade upgrade in _selection.CurrentTower.CurrentUpgrade.NextUpgrades)
			{
				Button button = Instantiate(_upgradeButtonPrefab, transform);
				button.image.sprite = upgrade.Icon;
				Upgrade u = upgrade;
				button.onClick.AddListener( delegate
				{
					ToggleRollout();
					if (OnUpgradeSelected != null) OnUpgradeSelected(u);
				});
				_buttons.Add(button);
			}
		}

		public event Action<Upgrade> OnUpgradeSelected;

		public void Collapse()
		{
			_buttonContainer.SetActive(false);
		}

		public void SetSprite(Sprite icon)
		{
			_mainButton.image.sprite = icon;
		}
	}
}