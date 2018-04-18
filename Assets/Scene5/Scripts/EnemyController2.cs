using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour {


	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () 
	{
		rigidBody = GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Enemy: Object entered the trigger: " + other.gameObject.name);
		if(other.gameObject.tag == "Player")
			target = other.gameObject;
	}

	void OnTriggerStay(Collider other)
	{

	}

	void OnTriggerExit(Collider other)
	{
		Debug.Log ("Object exited the trigger: " + other.gameObject.name);
		if(other.gameObject == target)
			target = null;
	}
	
	// Update is called once per frame
	void Update () 
	{



	}

	void FixedUpdate()
	{

		if (target /*&& Vector3.Distance(transform.position, target.transform.position) < range*/ ) 
		{
			//			Debug.Log ("Jestem blisko!");
			Vector3 targetDir = target.transform.position - transform.position;

			float step =  rotationSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0F);

			//Debug.DrawRay (transform.position, newDir, Color.red);

			transform.rotation = Quaternion.LookRotation (newDir);

			if (Vector3.Angle (targetDir, transform.forward) <= minAngle ) 
			{
				if (Vector3.Distance (transform.position, target.transform.position) >= minDistance ) {

					if (rigidBody.velocity.magnitude <= speed) 
					{
						targetDir *= speed;
						rigidBody.AddForce (targetDir);
						Debug.Log ("Velocity: " + rigidBody.velocity);
						//					rigidBody.MovePosition (transform.position + transform.forward * Time.deltaTime);
						//					rigidBody.velocity = targetDir * speed;
					} 
					else 
					{
						rigidBody.velocity = rigidBody.velocity.normalized * speed;
					}
				} else 
				{
					rigidBody.velocity = Vector3.zero;
				}
			}


		}
	}


	private GameObject target = null;
	public float range = 10.0F;
	public float minDistance = 2.0F;
	public float rotationSpeed = 5.0F;
	public float minAngle = 15.0f;
	public float speed = 10.0F;
	//public float maxSpeed = 10.0F;

}
