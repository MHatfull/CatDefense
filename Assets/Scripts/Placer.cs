using UnityEngine;
using UnityEngine.EventSystems;

namespace CatDefense
{
    public class Placer : MonoBehaviour
    {
        [SerializeField] private RangeRing _rangeRing;
        [SerializeField] private Color _placingColor;
        [SerializeField] private Color _errorColor;
        public Placeable CurrentlyPlacing { get; private set; }

        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit)) return;
            transform.position = hit.point;
            if (!CurrentlyPlacing) return;
            if (EventSystem.current.IsPointerOverGameObject()) return;
            if (GlobalData.Money < CurrentlyPlacing.Value) return;
            if (!hit.collider.gameObject.CompareTag("Ground"))
            {
                _rangeRing.SetColor(_errorColor);
                return;
            }
            _rangeRing.SetColor(_placingColor);
            if (!Input.GetMouseButtonDown(0)) return;
            CurrentlyPlacing.Clone(hit.point);
            GlobalData.Money -= CurrentlyPlacing.Value;
            SetCurrentTower(null);
        }

        public void SetCurrentTower(Placeable placeable)
        {
            _rangeRing.gameObject.SetActive(placeable);
            if (placeable)
            {
                Tower tower = placeable.GetComponent<Tower>();
                if(tower) _rangeRing.SetRange(tower.Range);
                else _rangeRing.SetRange(1);
            }
            CurrentlyPlacing = placeable;
        }
    }
}