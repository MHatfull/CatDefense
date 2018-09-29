using UnityEngine;

namespace CatDefense
{
	[RequireComponent(typeof(Projector))]
	public class RangeRing : MonoBehaviour
	{
		private Projector _projector;
		private Color _color;
		
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
			if (color == _color) return;
			_color = color;
			Material m = _projector.material;
			m.SetColor("_EdgeColor", color);
			m.SetColor("_FillColor", new Color(color.r, color.g, color.b, color.a * 0.5f));
		}

		public void Enable(bool on)
		{
			_projector.enabled = on;
		}
	}
}