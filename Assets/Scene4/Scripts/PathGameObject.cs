using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGameObject : PathBase {

	// Use this for initialization
	void Start () {
		for (int i = 0; i < points.Length; ++i) {
			//path.Add (Vector2.zero);
			base.path.Add (points [i].transform.position);
		}
	}
	
	// Update is called once per frame
	protected void Update () {
		base.Update ();
	}


	public GameObject[] points;
}
