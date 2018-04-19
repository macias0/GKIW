using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour {


	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	public void Footstep()
	{
		if (audioSource)
			audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
