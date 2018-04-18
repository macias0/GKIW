using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour {


	private static DontDestroy instance = null;

	void Awake()
	{
		if (instance == null) {

			instance = this;
			DontDestroyOnLoad (gameObject);
		} else
			Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene (0);
		}
	}
}
