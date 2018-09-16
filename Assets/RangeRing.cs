using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatDefense
{
	[RequireComponent(typeof(Projector))]
	public class RangeRing : MonoBehaviour
	{
		private Projector _projector;
		
		private void Awake()
		{
			_projector = GetComponent<Projector>();
		}

		public void SetRange(float r)
		{
			_projector.farClipPlane = r;
			_projector.nearClipPlane = -r;
			_projector.orthographicSize = r;
		}
	}
}