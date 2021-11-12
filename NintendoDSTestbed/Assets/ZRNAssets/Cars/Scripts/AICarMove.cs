using UnityEngine;
using System.Collections;

public class AICarMove : MonoBehaviour {

	[SerializeField]
	GameObject targetAICar;
	[SerializeField]
	GameObject[] targetNavMeshObjects;
	int targetNavMeshObjectCounts;
	public int targetNavMeshObjectNow;
	bool start=false;

	Vector3 startPos;
	Vector3 startRot;

	UnityEngine.AI.NavMeshAgent navMeshAgentCompornent;
	const float CAR_SPEED_MAX = 1.0f;

	// Use this for initialization
	void Start () {

		navMeshAgentCompornent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
		startPos = targetNavMeshObjects[0].transform.localPosition;
		startRot = targetNavMeshObjects[0].transform.localEulerAngles;
		targetNavMeshObjectCounts = targetNavMeshObjects.Length -1;

		targetNavMeshObjectNow = 1;
		InitAICar();

	}

	public void InitAICar () {

		//navMeshAgentCompornent.speed = 0.0f;
		targetAICar.GetComponent<Animation>().Play("00_Stop");
		//navMeshAgentCompornent.speed = CAR_SPEED_MAX;
		start = true;
		
		
	}



	
	// Update is called once per frame
	void Update () {

		if (start==true)
		{// Set destination
			
			navMeshAgentCompornent.SetDestination(targetNavMeshObjects[targetNavMeshObjectNow].transform.position);
			
			
			targetAICar.GetComponent<Animation>().Play("01_Run");
		}

		if (navMeshAgentCompornent.remainingDistance < 0.01f)
		{
			targetNavMeshObjectNow ++;
			if (targetNavMeshObjectNow <= targetNavMeshObjectCounts)
			{
				navMeshAgentCompornent.SetDestination(targetNavMeshObjects[targetNavMeshObjectNow].transform.position);
			}
			else if (targetNavMeshObjectNow >  targetNavMeshObjectCounts)
			{
				targetNavMeshObjectNow = 0;
				navMeshAgentCompornent.SetDestination(targetNavMeshObjects[targetNavMeshObjectNow].transform.position);
			}
		}

		else if (navMeshAgentCompornent.remainingDistance >= 0.01f)
        {

        }
	
	}
}
