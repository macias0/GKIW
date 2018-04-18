using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpriteController : MonoBehaviour {


	private Image img;

	// Use this for initialization
	void Start () {
		img = GetComponent<Image> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void setSprite(ItemBase item)
	{
		ItemBase.ItemType t = ItemBase.ItemType.None;
		if (item)
			t = item.itemType;

		for (int i = 0; i < map.Length; ++i) {
			if (t == map [i].type)
				img.sprite = map [i].sprite;
		}
			
	}

	[System.Serializable]
	public struct SpriteMap
	{
		public ItemBase.ItemType type;
		public Sprite sprite;
	}

	public SpriteMap[] map;
}
