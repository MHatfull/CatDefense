using UnityEngine;
using UnityEngine.UI;

namespace CatDefense
{
    [RequireComponent(typeof(Text))]
    public class PlacementUI : MonoBehaviour
    {
        private Tower _current;
        [SerializeField] private TowerPlacer _placer;

        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
            SetText();
        }

        private void Update()
        {
            if (_placer.CurrentTower == _current) return;
            _current = _placer.CurrentTower;
            SetText();
        }

        private void SetText()
        {
            if (_current)
                _text.text = "Placing " + _current.name + "\nCost: " + _current.Value;
            else
                _text.text = string.Empty;
        }
    }
}