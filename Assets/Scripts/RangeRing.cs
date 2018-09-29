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

		public void SetColor(Color color)
		{
			_projector.material.SetColor("_EdgeColor", color);
			_projector.material.SetColor("_FillColor", new Color(color.r, color.g, color.b, color.a * 0.5f));
		}
	}
}