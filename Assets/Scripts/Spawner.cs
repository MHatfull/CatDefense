using UnityEngine;
using UnityEngine.AI;

namespace CatDefence
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private NavMeshAgent _creep;
		[SerializeField] private Transform _target;

		private void Start()
		{
			InvokeRepeating("Spawn", 0, 1);
		}

		private void Spawn()
		{
			NavMeshAgent newCreep = Instantiate(_creep, transform.position, Quaternion.identity);
			newCreep.SetDestination(_target.position);
		}
	}
}