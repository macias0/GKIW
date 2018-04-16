using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected void Update () {
		if(draw)
			for(int i=0; i<path.Count; i++)
			{

				Vector3 pos = path [i];
				pos.y += 2.0F;
				Debug.DrawLine (path [i], pos, Color.red);
			}
	}

	public bool draw = false;
	public List<Vector3> path = new List<Vector3>();
	//public GameObject[] pathList;
}
