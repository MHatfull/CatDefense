using System.Collections;
using System.Collections.Generic;
using CatDefense;
using UnityEngine;

namespace CatDefense
{
	public class SwiperWeapon : TowerWeapon
	{
		public override void Fire(GameObject target)
		{
			target.GetComponent<Creep>().DealDamage(50);
		}
	}
}