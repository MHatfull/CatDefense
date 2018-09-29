using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace CatDefense
{
	public class Tower : Placeable
	{
		[SerializeField] private float _fireRate = 1;
		[SerializeField] private Transform _weaponContainer;
		[SerializeField] private Animator _animator;
		[SerializeField] private float _range = 100;
		[SerializeField] private int _value = 50;
		[SerializeField] private int[] _upgradeCost;
		[SerializeField] private RangeRing _rangeRing;

		[SerializeField] private Upgrade _currentUpgrade;
		public Upgrade CurrentUpgrade
		{
			get { return _currentUpgrade; }
		}
		
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

		public int UpgradeLevel { get; private set; }

		public int UpgradeCost
		{
			get { return _upgradeCost[UpgradeLevel]; }
		}

		//public List<Upgrade> Upgrades { get; private set; } = new List<Upgrade>();

		public override Placeable Clone(Vector3 hitPoint)
		{
			Tower clone = Instantiate(this, hitPoint, Quaternion.identity);
			FindObjectOfType<TowerSelection>().SelectTower(clone);
			return clone;
		}

		private void Awake()
		{
			_weapon = Instantiate(_currentUpgrade.Weapon, _weaponContainer.position, _weaponContainer.rotation, _weaponContainer);
		}

		private void Start()
		{
			InvokeRepeating("Fire", _fireRate, _fireRate);
		}

		private void OnMouseEnter()
		{
			_rangeRing.Enable(true);
			_rangeRing.SetRange(_range);
		}
		
		private void OnMouseExit()
		{
			_rangeRing.Enable(_selected);
			_rangeRing.SetRange(_range);
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
			_weaponContainer.LookAt(closest.transform);
			_animator.SetTrigger("Fire");
			_weapon.Fire(closest);
		}

		public void SetSelected(bool selected)
		{
			_selected = selected;
			_rangeRing.Enable(selected);
			_rangeRing.SetRange(_range);
		}

		public void Upgrade(Upgrade upgrade)
		{
			if (GlobalData.Money < _upgradeCost[UpgradeLevel]) return;
			GlobalData.Money -= _upgradeCost[UpgradeLevel];
			UpgradeLevel++;
			_currentUpgrade = upgrade;
			Destroy(_weapon.gameObject);
			_weapon = Instantiate(upgrade.Weapon, _weaponContainer.position, _weaponContainer.rotation, _weaponContainer);
		}
	}
}