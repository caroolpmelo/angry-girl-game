using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Npc : MonoBehaviour
{
    private bool _canOpenStore = false;

    private float _npcYPosition = -2.5f;

    [SerializeField]
    private SceneAsset _shop;
    [SerializeField]
    private GameObject _shopPopUp;

    private GameObject _mainCamera;
    private GameController _gameController;

    void Start()
    {
        transform.position = new Vector3(6f, _npcYPosition);

        _mainCamera = GameObject.Find("Main Camera"); // sets main camera game object
        // get game controller to access freeze coins
        _gameController = _mainCamera.GetComponent<GameController>();
    }

    void Update()
    {
        OpenStore();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // while player is in contact with npc
        if (collision.tag.Equals("Player") && !_canOpenStore)
        {
            _canOpenStore = true;
            Debug.Log("npc is here");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // when player is not in contact
        if (collision.tag.Equals("Player") && _canOpenStore)
        {
            _canOpenStore = false;
            Debug.Log("npc is NOT here");
        }
    }

    private void OpenStore()
    {
        bool spacePressed = Input.GetKeyDown(KeyCode.Space);
        bool shopIsLoaded = SceneManager.GetSceneByName("Shop").isLoaded;

        // open store if next to npc and press space
        if (_canOpenStore && spacePressed && !shopIsLoaded)
        {
            Debug.Log("open shop");
            _gameController.FreezeCoins = true;
            SceneManager.LoadScene("Shop", LoadSceneMode.Additive);

        }

        // to close the store, but needs to be next to npc
        if (_canOpenStore && spacePressed && shopIsLoaded)
        {
            Debug.Log("close shop");
            _gameController.FreezeCoins = false;
            SceneManager.UnloadSceneAsync("Shop", UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        }
    }
}
