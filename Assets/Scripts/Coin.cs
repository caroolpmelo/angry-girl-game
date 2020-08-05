using UnityEngine;

public class Coin : MonoBehaviour
{
    private enum _Colors
    {
        Blue,
        Green,
        Grey,
        Red,
        Yellow
    }

    [SerializeField]
    private _Colors _color;

    private int _quantity;

    private readonly float timeLimit = 5f;

    void Start()
    {
        System.Random rand = new System.Random();
        // set random value for coin qtt
        _quantity = rand.Next(1, 11);
    }

    void Update()
    {
        CheckTimeLimit();
    }

    // checks every frame if coin should disappear
    private void CheckTimeLimit()
    {
        if (Time.deltaTime % timeLimit == 0) 
        {
            Debug.Log(Time.deltaTime);
        }
        //if (Time.fixedTime % 5 == 0) // multiple of 5
        //{
        //    Debug.Log("passou 5 segundos");
        //}
    }
}
