using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void StartGame()
	{
		sceneSelect.SetActive (true);
		menu.SetActive (false);
	}

	public void LoadScene(string buttonName)
	{
		SceneManager.LoadScene (int.Parse (buttonName));
	}


	public void Info()
	{
		info.SetActive (true);
		menu.SetActive (false);
	}

	public void Exit()
	{
		Application.Quit ();
	}


	public void Back()
	{
		menu.SetActive (true);
		info.SetActive (false);
		sceneSelect.SetActive (false);
	}

	public GameObject menu = null;
	public GameObject info = null;
	public GameObject sceneSelect = null;
}
