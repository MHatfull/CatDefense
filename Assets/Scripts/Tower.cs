using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CatDefence
{
	public class Tower : MonoBehaviour
	{
		[SerializeField] private float _fireRate = 1;
		[SerializeField] private Rigidbody _projectile;
		[SerializeField] private float _projectileSpeed = 10;
		[SerializeField] private Transform _cannonLocation;

		private void Start()
		{
			Debug.Log("starting");
			InvokeRepeating("Fire", _fireRate, _fireRate);
		}

		private void Fire()
		{
			Debug.Log("fire fire fier");
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			Debug.Log("have enemies: " + enemies.Length);
			if (enemies.Length == 0) return;
			GameObject closest = enemies.OrderBy(e => Vector3.Distance(e.transform.position, transform.position)).First();
			Rigidbody projectile = Instantiate(_projectile, _cannonLocation.position, Quaternion.identity);
			projectile.velocity = (closest.transform.position - _cannonLocation.position).normalized * _projectileSpeed;
			Debug.Log("projectile away");
		}

	}
}