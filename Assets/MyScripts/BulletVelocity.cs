using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVelocity : MonoBehaviour
{
    //The velocity
	private GameObject FireballMovementInput;
	private Rigidbody PlayerRB;
	private Rigidbody BulletRB;
	private Animator PlayerAnim;
	private float Speed = 10;

	void Start()
    {
		PlayerAnim = GameObject.Find("PlayerCharacter").GetComponent<Animator>();
		FireballMovementInput = GameObject.Find("PlayerCharacter");
		PlayerRB = FireballMovementInput.GetComponent<Rigidbody>();
		BulletRB = GetComponent<Rigidbody>();
		BulletRB.velocity = new Vector3(PlayerAnim.GetFloat("MovementX"), PlayerAnim.GetFloat("MovementY"), 0).normalized * Speed;
	}

	void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Slime")
		{
			Destroy(gameObject);
		}
	}

	void Awake()
	{
		
	}

	void FixedUpdate()
	{

		
	}
}
