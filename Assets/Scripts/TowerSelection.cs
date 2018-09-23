using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CatDefense
{
    public class TowerSelection : MonoBehaviour
    {
        private Tower _currentTower;
        [SerializeField] private Text _text;

        private void Start()
        {
            _text.text = string.Empty;
        }

        public void SelectTower(Tower tower)
        {
            if(_currentTower)
                _currentTower.SetSelected(false);
            _currentTower = tower;
            _currentTower.SetSelected(true);
            _text.text = "Selected: " + tower.name;
        }

        private void Update()
        {
            if(!Input.GetMouseButtonDown(0)) return;

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