using UnityEngine;
using UnityEngine.AI;

public class AIcontroller : MonoBehaviour
{
	private GameObject destination;

	private NavMeshAgent agent;

	private void Start()
	{
		destination = GameObject.FindGameObjectWithTag("Player");
		agent = GetComponent<NavMeshAgent>();
	}

	private void Update()
	{
		agent.SetDestination(destination.transform.position);
		FaceTarget();
	}

	private void FaceTarget()
	{
		Vector3 normalized = (agent.destination - base.transform.position).normalized;
		Quaternion b = Quaternion.LookRotation(new Vector3(normalized.x, 0f, normalized.z));
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * 5f);
	}
}
