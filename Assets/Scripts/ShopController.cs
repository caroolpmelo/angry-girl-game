using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField]
    private StoreItem[] _items = new StoreItem[15];

    [SerializeField]
    private List<StoreItem> _randomItems = new List<StoreItem>();

    private GameObject _canvas;
    private GameObject _itemsGameObject;

    [SerializeField]
    private GameObject _selector;

    System.Random rand = new System.Random();

    void Start()
    {
        _canvas = GameObject.Find("CanvasShop");

        // creates an empty Items game object to organize the items for this playthrough
        _itemsGameObject = new GameObject("Items");
        _itemsGameObject.transform.SetParent(_canvas.transform, false);

        RandomizeItems();
        FillStore();
        CreateSelector();
    }

    void Update()
    {
        IsItemSelected();
    }

    // randomize shop items in the session
    void RandomizeItems()
    {
        int idNumber;
        // list of chosen items, to avoid repetition
        List<int> chosenItemsIds = new List<int>();

        for (int i = 0; i < 5; i++) // loop to choose 5 items
        {
            do
            {
                idNumber = rand.Next(1, 16); // randomize between 1 and 15
            } while (chosenItemsIds.Contains(idNumber));
            chosenItemsIds.Add(idNumber); // adds non-repetible ids
        }

        // search all items by randomized ids
        foreach (StoreItem item in _items)
        {
            if (chosenItemsIds.Contains(item.Id)) // random id is on chosen ones list
            {
                item.Coin = RandomizeCoinProp(); // randomize coin prop
                _randomItems.Add(item); // adds 'unique' item
            }
        }
    }

    // randomize coins prefab to set item coin prop
    Object RandomizeCoinProp()
    {
        Object[] coins = Resources.LoadAll("coins"); // get all coins prefabs resources
        return coins[rand.Next(0, coins.Length)]; // set item with a random index
    }

    // place chosen items in Shop canvas
    void FillStore()
    {
        foreach (StoreItem item in _randomItems)
        {
            // create the item game object inside the Canvas game object
            GameObject itemGameObject = Instantiate(item.gameObject, Vector3.zero, Quaternion.Euler(Vector3.zero));
            itemGameObject.transform.SetParent(_itemsGameObject.transform, false);
        }
    }

    // creates the selector game object
    void CreateSelector()
    {
        Object selectorResource = Resources.Load("Selector"); // load the Selector
        // instantiate selector in the scene
        GameObject selectorGameObject = Instantiate(selectorResource, Vector3.zero, Quaternion.Euler(Vector3.zero)) as GameObject;
        // set ir as the Items game object field, so it stays together with the products
        selectorGameObject.transform.SetParent(_itemsGameObject.transform, false);

        _selector = selectorGameObject;
    }

    void IsItemSelected() // TODO: pass the select item as parameter
    {
        //if (item.IsSelected && !_selector.activeSelf)
        //{
        //    _selector.SetActive(true);
        //}
        //else if (item.IsSelected && _selector.activeSelf)
        //{
        //    _selector.SetActive(false);
        //}
    }
}
