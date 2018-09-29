using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CatDefense
{
	public class PhaseController : MonoBehaviour
	{
		private Spawner[] _spawners;
		private enum Phase { Building, Defending }
		private Phase _phase = Phase.Building;

		private void Awake()
		{
			_spawners = Transform.FindObjectsOfType<Spawner>();
		}

		private void Update()
		{
			if (_phase == Phase.Building && Input.GetKeyDown(KeyCode.Space))
			{
				StartWave();
			}
		}

		private void StartWave()
		{
			_phase = Phase.Defending;
			if (_spawners.All(s => s.SpawnComplete)) return;
			foreach (Spawner spawner in _spawners)
			{
				spawner.StartWave();
			}
		}
	}
}