using System.Linq;
using UnityEngine;

namespace CatDefense
{
	[RequireComponent(typeof(TowerWeapon))]
	public class Tower : MonoBehaviour
	{
		[SerializeField] private float _fireRate = 1;
		[SerializeField] private Transform _cannonModel;
		[SerializeField] private Animator _animator;
		[SerializeField] private float _range = 100;
		[SerializeField] private int _value = 50;

		private TowerWeapon _weapon;
		public int Value
		{
			get { return _value; }
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
			_weapon.DisplayRange(_range, false);
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
	}
}