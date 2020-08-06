using UnityEngine;

public class Coin : MonoBehaviour
{
    public enum Colors
    {
        Blue,
        Green,
        Grey,
        Red,
        Yellow
    }

    [SerializeField]
    private Colors _color;

    private float _initializationTime;
    private float _timeSinceInitialization;
    private readonly float _timeLimit = 5f;

    private GameObject _mainCamera;
    private GameController _gameController;

    void Start()
    {
        _mainCamera = GameObject.Find("Main Camera");
        _gameController = _mainCamera.GetComponent<GameController>();

        _initializationTime = Time.timeSinceLevelLoad;
    }

    void Update()
    {
        CheckCoinDestruction();
    }

    // checks if how much time has passed since creation for destruction
    private void CheckCoinDestruction()
    {
        _timeSinceInitialization = Time.timeSinceLevelLoad - _initializationTime;
        if (_timeSinceInitialization > _timeLimit)
        {
            Destroy(gameObject); // auto destruction
        }
    }

    // detects if coin is catched
    private void OnTriggerStay2D(Collider2D collision)
    {
        // while player is in contact with coin
        if (collision.tag.Equals("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("ADD coin");
            _gameController.CatchCoin(this);
            Destroy(gameObject); // player catch coin
        }
    }
}
