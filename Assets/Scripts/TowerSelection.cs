using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CatDefense
{
    public class TowerSelection : MonoBehaviour
    {
        public Tower CurrentTower { get; private set; }
        [SerializeField] private Text _text;
        [SerializeField] private Text _upgradeCost;
        [SerializeField] private UpgradeButton[] _upgradeButtons;

        private void Start()
        {
            _text.text = string.Empty;
            ActivateRelevantUpgradeButton(null);
            for (int i = 0; i < _upgradeButtons.Length; i++)
            {
//                if (CurrentTower.UpgradeLevel <= i)
//                {
//                    _upgradeButtons[i].SetSprite(CurrentTower.Upgrades[i].Icon);
//                }
//                else
//                {
//                    _upgradeButtons[i].SetSprite(null);
//                }

                _upgradeButtons[i].OnUpgradeSelected += (upgrade) =>
                {
                    if(CurrentTower) CurrentTower.Upgrade(upgrade);
                    ActivateRelevantUpgradeButton(CurrentTower);
                    SetUpgradeCostText(CurrentTower);
                };
            }
        }

        public void SelectTower(Tower tower)
        {
            if(CurrentTower)
                CurrentTower.SetSelected(false);
            CurrentTower = tower;
            CurrentTower.SetSelected(true);
            _text.text = "Selected: " + tower.name;
            SetUpgradeCostText(tower);
            ActivateRelevantUpgradeButton(tower);
        }

        private void SetUpgradeCostText(Tower tower)
        {
            _upgradeCost.text = "Upgrade cost: " + tower.UpgradeCost;
        }

        private void ActivateRelevantUpgradeButton(Tower tower)
        {
            for (int i = 0; i < _upgradeButtons.Length; i++)
            {
                _upgradeButtons[i].interactable = tower && i == tower.UpgradeLevel;
            }
        }

        private void Update()
        {
            if(!Input.GetMouseButtonDown(0)) return;
            if (EventSystem.current.IsPointerOverGameObject()) return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit)) return;
            if (!hit.collider.GetComponent<Tower>())
            {
                RemoveSelection();
            }
        }

        public void RemoveSelection()
        {
            if(CurrentTower)
                CurrentTower.SetSelected(false);
            CurrentTower = null;
            _text.text = string.Empty;
            ActivateRelevantUpgradeButton(null);
            _upgradeCost.text = "Upgrade cost: ";
            foreach (UpgradeButton upgradeButton in _upgradeButtons)
            {
                upgradeButton.Collapse();
            }
        }
        
    }
}