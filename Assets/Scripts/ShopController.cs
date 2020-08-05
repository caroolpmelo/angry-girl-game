using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField]
    private StoreItem[] _items = new StoreItem[15];
    [SerializeField] // TODO: remover
    private List<StoreItem> _randomItems = new List<StoreItem>();

    System.Random rand = new System.Random();

    void Start()
    {
        RandomizeItems();
    }

    void Update()
    {
    }

    // randomize shop items in the session
    void RandomizeItems()
    {
        int idNumber;
        // list of chosen items, to avoid repetition
        List<int> chosenItemsIds = new List<int>();

        for (int i = 0; i < 5; i++) // chooses 5 items
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
}
