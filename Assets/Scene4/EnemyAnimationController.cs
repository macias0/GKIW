using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {


		Vector3 targetDir = path.path[pathIndex] - transform.position;

		if (Vector3.Angle (targetDir, transform.forward) > boundaryAngle) {
//			Debug.Log ("Zatrzymuje animacje, czekam na obrot");
			animator.SetFloat ("speed", 0.0F);
			rotating = true;
		} else
			rotating = false;

		float step =  rotationSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0F);

		//ignore Y
		newDir.y = 0.0F;

		//Debug.DrawRay (transform.position, newDir, Color.red);

		transform.rotation = Quaternion.LookRotation (newDir);

		//		if (Vector3.Angle (targetDir, transform.forward) <= minAngle ) 
		//		{

		if (!rotating) {

			if (Vector3.Distance (transform.position, path.path [pathIndex]) > minDistance) {
				
				animator.SetFloat ("speed", 2.0F);
			} else {
				

				if (pathIndex + 1 < path.path.Count)
					pathIndex++;
				else {
					if (loop)
						pathIndex = 0;
					else
						animator.SetFloat ("speed", 0.0F);
				}
			}
		}
		

	}


	private int pathIndex = 0;
	private bool rotating = false;

	private Animator animator;

	public PathBase path;
	public float minDistance = 1.5F;
	public float boundaryAngle = 0.0F;
	public float rotationSpeed = 5.0F;
	public bool loop = false;
}
