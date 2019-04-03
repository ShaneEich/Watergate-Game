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

    public GameObject inventoryGUI;
    Inventory inventory;	// Our current inventory
    private bool currentState = false;

    public int space = 10;	// Amount of item spaces

	// Our current list of items in the inventory
	public List<Item> items = new List<Item>();

    private void Update()
    {
        UpdateUI();
    }
           
    void LateUpdate()
    {
        OpenOrClose(currentState);
    }

    //method to set the inventory GUI to active by preessing 'I'
    public void Open()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryGUI.SetActive(true);
        }
    }

    //method to set the inventory GUI to inactive by preessing 'I'
    public void Close()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryGUI.SetActive(false);
        }
    }

    public void OpenOrClose(bool state)
    {
        state = !currentState;
        currentState = state;
        if (state == true)
        {
            Open();
        }
        if (state == false)
        {
            Close();
        }
    }

    public void UpdateUI()
    {
        InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

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
