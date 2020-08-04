using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _coins = new List<GameObject>();
    private bool _freezeCoins = false;

    [SerializeField]
    GameObject blueCoin;
    [SerializeField]
    GameObject greenCoin;
    [SerializeField]
    GameObject greyCoin;
    [SerializeField]
    GameObject redCoin;
    [SerializeField]
    GameObject yellowCoin;

    void Start()
    {
    }

    void Update()
    {
        InstantiateCoins();
    }

    private void InstantiateCoins() 
    {
        //Instantiate(blueCoin);
    }
}
