using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // collected coins
    [SerializeField]
    private List<Coin> _catchedCoins = new List<Coin>();

    private List<GameObject> _availableCoins = new List<GameObject>(); // prefabs of the coins
    
    public bool FreezeCoins { get; set;  }

    private float _coinYPosition = -3f;

    private float _coinInstationTiming = 2f; // time to wait between coins stations

    private GameObject _coinsStorage;

    // coins prefabs
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

    // TODO: pop up scenes (shop is on npc script)
    //private Scene _wallet = SceneManager.LoadScene(3);
    //private Scene _mainGame = SceneManager.LoadScene(0);
    //private Scene _inventory = SceneManager.LoadScene(2);

    System.Random rand = new System.Random();

    void Start()
    {
        FreezeCoins = false;

        // adds coins to list to randomize for appearance
        _availableCoins.Add(blueCoin);
        _availableCoins.Add(greenCoin);
        _availableCoins.Add(greyCoin);
        _availableCoins.Add(redCoin);
        _availableCoins.Add(yellowCoin);

        // creates game object to store the generated coins
        _coinsStorage = new GameObject("Coins");

        InvokeRepeating("InstantiateRandomCoins", _coinInstationTiming, _coinInstationTiming);
    }

    // instantiate coins randomdly in the floor bounds
    private void InstantiateRandomCoins() 
    {
        if (!FreezeCoins)
        {
            int index = rand.Next(0, _availableCoins.Count); // random coin from list
            float randomXAxis = rand.Next(-6, 6); // random x axis position (-6 and 6 are the bounds)
            Vector3 randomPosition = new Vector3(randomXAxis, _coinYPosition);

            GameObject newCoin = Instantiate(_availableCoins[index], randomPosition, Quaternion.Euler(Vector3.zero));
            newCoin.transform.SetParent(_coinsStorage.transform, false); // put it inside Coins game object
        }
    }

    // called in Coin script to add object to list
    public void CatchCoin(Coin catchedCoin)
    {
        _catchedCoins.Add(catchedCoin);
    }
}
