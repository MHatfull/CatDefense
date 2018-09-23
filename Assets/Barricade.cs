using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatDefense
{
	public class Barricade : Placeable
	{
		[SerializeField] private int _value;

		public override int Value
		{
			get { return _value; }
		}

		public override Placeable Clone(Vector3 hitPoint)
		{
			return Instantiate(this, hitPoint, Quaternion.identity);
		}
	}
}