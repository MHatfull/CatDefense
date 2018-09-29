using System.Collections;
using System.Collections.Generic;
using CatDefense;
using UnityEngine;

namespace CatDefense
{
	public class MageWeapon : TowerWeapon
	{
		[SerializeField] private GameObject _projectile;
		
		public override void Fire(GameObject target)
		{
			var bullet = Instantiate(_projectile, transform.position, Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up));
			var tm = bullet.GetComponentInChildren<RFX4_TransformMotion>(true);
			if (tm!=null) tm.CollisionEnter += BulletHit;
		}

		private void BulletHit(object sender, RFX4_TransformMotion.RFX4_CollisionInfo e)
		{
			if (e.Hit.transform.CompareTag("Enemy"))
			{
				e.Hit.transform.GetComponent<Creep>().DealDamage(50);
			}
		}
	}
}