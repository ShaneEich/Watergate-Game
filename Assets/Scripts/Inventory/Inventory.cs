using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	#region Singleton

	public static Inventory instance;

	void Awake ()
	{
		instance = this;
	}

	#endregion

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

    // public GameObject inventoryGUI;
    //private bool currentState = false;

    Inventory inventory;	// Our current inventory
    public int space = 12;	// Amount of item spaces

	// Our current list of items in the inventory
	public List<Item> items = new List<Item>();

    //private void Update()
    //{
        
    //}
           
    //void LateUpdate()
    //{
    //    OpenOrClose(currentState);
    //}

    ////method to set the inventory GUI to active by preessing 'I'
    //public void Open()
    //{
    //    if (Input.GetKeyDown(KeyCode.I))
    //    {
    //        inventoryGUI.SetActive(true);
    //    }
    //}

    ////method to set the inventory GUI to inactive by preessing 'I'
    //public void Close()
    //{
    //    if (Input.GetKeyDown(KeyCode.I))
    //    {
    //        inventoryGUI.SetActive(false);
    //    }
    //}

    //public void OpenOrClose(bool state)
    //{
    //    state = !currentState;
    //    currentState = state;
    //    if (state == true)
    //    {
    //        Open();
    //    }
    //    if (state == false)
    //    {
    //        Close();
    //    }
    //}

    // Add a new item if enough room
    public void Add (Item item)
	{
		if (item.showInInventory) {
			if (items.Count >= space) {
				Debug.Log ("Not enough room.");
				return;
			}

			items.Add (item);

			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke ();
		}
	}

	// Remove an item
	public void Remove (Item item)
	{
		items.Remove(item);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

}
