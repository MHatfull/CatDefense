using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CatDefense
{
    public class TowerSelection : MonoBehaviour
    {
        private Tower _currentTower;
        [SerializeField] private Text _text;
        [SerializeField] private UpgradeButton[] _upgradeButtons;

        private void Start()
        {
            _text.text = string.Empty;
            ActivateRelevantUpgradeButton(null);
        }

        public void SelectTower(Tower tower)
        {
            if(_currentTower)
                _currentTower.SetSelected(false);
            _currentTower = tower;
            _currentTower.SetSelected(true);
            _text.text = "Selected: " + tower.name;
            ActivateRelevantUpgradeButton(tower);
            for (int i = 0; i < _upgradeButtons.Length; i++)
            {
                _upgradeButtons[i].OnUpgradeSelected += () =>
                {
                    tower.Upgrade();
                    ActivateRelevantUpgradeButton(_currentTower);
                };
            }
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
            if(_currentTower)
                _currentTower.SetSelected(false);
            _currentTower = null;
            _text.text = string.Empty;
        }
        
    }
}