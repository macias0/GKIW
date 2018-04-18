using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () 
	{
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (target && Vector3.Distance(transform.position, target.transform.position) < range ) 
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

	void FixedUpdate()
	{


	}


	public GameObject target = null;
	public float range = 10.0F;
	public float minDistance = 2.0F;
	public float rotationSpeed = 5.0F;
	public float minAngle = 15.0f;
	public float speed = 10.0F;
	//public float maxSpeed = 10.0F;

}
