using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace CatDefense
{
	public class Creep : MonoBehaviour
	{
		[SerializeField] private float _health = 100;
		[SerializeField] private int _value = 10;
		[SerializeField] private NavMeshAgent _navMeshAgent;

		public void DealDamage(float amount)
		{
			_health -= amount;
			if (_health <= 0)
			{
				Destroy(gameObject);
				GlobalData.Money += _value;
			}
		}

		public void SetDestination(Vector3 targetPosition)
		{
			_navMeshAgent.SetDestination(targetPosition);
		}
	}
}