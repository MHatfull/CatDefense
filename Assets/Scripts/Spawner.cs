using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace CatDefense
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private Wave[] _waves;
		[SerializeField] private Transform _target;

		private int _waveNumber = 0;

		public delegate void WaveCompleteHandler();
		public event WaveCompleteHandler OnWaveComplete;

		public bool NoMoreWaves
		{
			get { return _waveNumber >= _waves.Length; }
		}
		
		public void StartWave()
		{
			StartCoroutine(Spawn());
		}

		private IEnumerator Spawn()
		{
			if (!_target || NoMoreWaves)
			{
				if (OnWaveComplete != null) OnWaveComplete();
				yield break;
			}

			foreach (Release release in _waves[_waveNumber].Releases)
			{
				for (int i = 0; i < release.Size; i++)
				{
					yield return new WaitForSeconds(release.ReleaseDelay); 
					Creep newCreep = Instantiate(release.Creep, transform.position, Quaternion.identity);
					newCreep.SetDestination(_target.position);
				}
			}

			_waveNumber++;
			if (OnWaveComplete != null) OnWaveComplete();
		}
		
		[Serializable]
		private class Wave
		{
			[SerializeField] private Release[] _releases;
			public Release[] Releases
			{
				get { return _releases; }
			}
		}
		
		[Serializable]
		private class Release
		{
			[SerializeField] private int _size;
			public int Size
			{
				get { return _size; }
			}
			
			[SerializeField] private Creep _creep;
			public Creep Creep
			{
				get { return _creep; }
			}

			[SerializeField] private float _releaseDelay;

			public float ReleaseDelay
			{
				get { return _releaseDelay; }
			}
		}
	}
}