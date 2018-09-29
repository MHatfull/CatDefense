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
            if (Input.GetMouseButtonDown(1)) SetCurrentTower(null);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit)) return;
            transform.position = hit.point;
            if (!CurrentlyPlacing 
                || EventSystem.current.IsPointerOverGameObject()
                || GlobalData.Money < CurrentlyPlacing.Value 
                || !hit.collider.gameObject.CompareTag("Ground"))
            {
                _rangeRing.SetColor(_errorColor);
                if(Input.GetMouseButton(0)) SetCurrentTower(null);
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
            _rangeRing.Enable(placeable);
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