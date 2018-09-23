using UnityEngine;
using UnityEngine.UI;

namespace CatDefense
{
    [RequireComponent(typeof(Text))]
    public class PlacementUI : MonoBehaviour
    {
        private Placeable _current;
        [SerializeField] private Placer _placer;

        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
            SetText();
        }

        private void Update()
        {
            if (_placer.CurrentlyPlacing == _current) return;
            _current = _placer.CurrentlyPlacing;
            SetText();
        }

        private void SetText()
        {
            if (_current != null)
                _text.text = "Placing " + _current.name + "\nCost: " + _current.Value;
            else
                _text.text = string.Empty;
        }
    }
}