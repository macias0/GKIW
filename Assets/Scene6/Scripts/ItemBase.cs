using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBase : MonoBehaviour {




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		



	public enum ItemType{None, Sword, Bow, Scroll};
//	static public string spritesPathPrefix = "RPG_inventory_icons/";
//	static public string[] spriteNames = {""};
	public ItemType itemType;
}
