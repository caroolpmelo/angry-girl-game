using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField]
    private StoreItem[] _items = new StoreItem[15];
    private List<StoreItem> _randomItems = new List<StoreItem>();

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

        System.Random rand = new System.Random();

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
            if (chosenItemsIds.Contains(item.Id))
            {
                _randomItems.Add(item); // adds 'unique' item
            }
        }
    }
}
