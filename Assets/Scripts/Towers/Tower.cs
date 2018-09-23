using System.Linq;
using UnityEngine;

namespace CatDefense
{
	[RequireComponent(typeof(TowerWeapon))]
	public class Tower : Placeable
	{
		[SerializeField] private float _fireRate = 1;
		[SerializeField] private Transform _cannonModel;
		[SerializeField] private Animator _animator;
		[SerializeField] private float _range = 100;
		[SerializeField] private int _value = 50;

		private TowerWeapon _weapon;
		private bool _selected;

		public override int Value
		{
			get { return _value; }
		}

		public float Range
		{
			get { return _range; }
		}

		public override Placeable Clone(Vector3 hitPoint)
		{
			Tower clone = Instantiate(this, hitPoint, Quaternion.identity);
			clone.SetSelected(true);
			return clone;
		}

		private void Awake()
		{
			_weapon = GetComponent<TowerWeapon>();
		}

		private void Start()
		{
			InvokeRepeating("Fire", _fireRate, _fireRate);
		}

		private void OnMouseEnter()
		{
			_weapon.DisplayRange(_range, true);
		}
		
		private void OnMouseExit()
		{
			_weapon.DisplayRange(_range, _selected);
		}

		private void OnMouseUpAsButton()
		{
			FindObjectOfType<TowerSelection>().SelectTower(this);
		}

		private void Fire()
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			if (enemies.Length == 0) return;
			GameObject closest = enemies.OrderBy(e => Vector3.Distance(e.transform.position, transform.position)).First();
			if(Vector3.Distance(closest.transform.position, transform.position) > _range) return;
			_cannonModel.LookAt(closest.transform);
			_animator.SetTrigger("Fire");
			_weapon.Fire(closest);
		}

		public void SetSelected(bool selected)
		{
			_selected = selected;
			_weapon.DisplayRange(_range, selected);
		}
	}
}