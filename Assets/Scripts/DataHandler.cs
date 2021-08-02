using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class DataHandler : MonoBehaviour
{
    private GameObject furniture;

    [SerializeField] private ButtonManager buttonPrefab; //Serialize field so we can see it from Unity editor
    [SerializeField] private GameObject buttonContainer;

    [SerializeField] private List<Item> items;

    [SerializeField] private String label;
    private int current_id = 0;

    private static DataHandler instance;
    public static DataHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }
    }

    private async void Start()
    {
        items = new List<Item>();
        //LoadItems();
        
        await Get(label);
        CreateButtons();
    }

    //dynamically add items to datamanager
    //void LoadItems()
    //{
      // var items_obj = Resources.LoadAll("Items", typeof(Item));
     //  foreach (var item in items_obj)
      //{
      //      items.Add(item as Item);
       // }
   //  }

    //this class will create buttons dynamically
    void CreateButtons() // script table object = stores data in the class which doesnt destroy during play mode
    {
        foreach (Item i in items)
        {
            ButtonManager b = Instantiate(buttonPrefab, buttonContainer.transform);
            b.ItemId = current_id;
            b.ButtonTexture = i.itemImage;
            current_id++;
        }
    }

    public void SetFurniture(int id)
    {
        furniture = items[id].itemPrefab;
    }

    public GameObject GetFurniture()
    {
        return furniture;
    }
    public async Task Get(String label)
    {
        var locations = await Addressables.LoadResourceLocationsAsync(label).Task; // used for enumeration
        foreach (var location in locations)
        {
            var obj = await Addressables.LoadAssetAsync<Item>(location).Task;
            items.Add(obj);
        }
    }

}
