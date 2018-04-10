using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{
		Event e = Event.current;
		if (e.isKey && e.type == EventType.KeyDown) 
		{
			if (e.keyCode == KeyCode.Alpha1) 
			{
				cam2.gameObject.SetActive (false);
				cam1.gameObject.SetActive (true);
			} 
			else if (e.keyCode == KeyCode.Alpha2) 
			{
				cam1.gameObject.SetActive (false);
				cam2.gameObject.SetActive (true);
			}
		}
	}


	public Camera cam1 = null;
	public Camera cam2 = null;
}
