using System.Linq;
using UnityEngine;

namespace CatDefense
{
	public class PhaseController : MonoBehaviour
	{
		private Spawner[] _spawners;
		private enum Phase { Building, Defending }
		private Phase _phase = Phase.Building;

		private int _currentlySpawning;

		private void Awake()
		{
			_spawners = FindObjectsOfType<Spawner>();
			foreach (Spawner spawner in _spawners)
			{
				spawner.OnWaveComplete += OnSpawnWaveComplete;
			}
		}

		private void OnSpawnWaveComplete()
		{
			_currentlySpawning--;
			if (_currentlySpawning == 0)
				_phase = Phase.Building;
		}
		
		private void Update()
		{
			if (_phase != Phase.Building
			    || !Input.GetKeyDown(KeyCode.Space)
			    || _spawners.All(s => s.NoMoreWaves) 
			    || _currentlySpawning > 0
			    || FindObjectsOfType<Creep>().Any()) return;
			
			StartWave();
		}

		private void StartWave()
		{		
			_phase = Phase.Defending;
			_currentlySpawning = _spawners.Count(s => !s.NoMoreWaves);
			foreach (Spawner spawner in _spawners)
			{
				spawner.StartWave();
			}
		}
	}
}