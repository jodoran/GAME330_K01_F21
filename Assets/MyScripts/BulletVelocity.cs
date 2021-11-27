using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVelocity : MonoBehaviour
{
    //The velocity
    public Vector3 BulletVelocity1;
	private GameObject FireballMovementInput;
	private Rigidbody PlayerRB;
	private Rigidbody BulletRB;



	void Start()
    {
		FireballMovementInput = GameObject.Find("PlayerCharacter");
		PlayerRB = FireballMovementInput.GetComponent<Rigidbody>();
		BulletRB = GetComponent<Rigidbody>();
		//BulletVelocity1 = BulletRB.velocity;
	}
	void Awake()
	{
		
	}

	void FixedUpdate()
	{

		//GetComponent<Rigidbody>().velocity = PlayerRB.velocity;
		BulletRB.velocity = PlayerRB.velocity * 5;
	}
}
