using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _velocity = 5f;
    private bool _canOpenStore = false;

    void Start()
    {
        transform.position = new Vector3(-6f, -2f);
    }

    void Update()
    {
        MovePlayer();
        OpenStore();
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, -2f);

        if (_velocity != 0)
        {
            transform.Translate(direction * _velocity * Time.deltaTime);
        } else if (_velocity == 0)
        {
            Debug.Log("Posicao:" + transform.position);
            Debug.Log("Ajustar a física para o player não parar");
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.2f, 8.2f), -2f);
    }

    private void OpenStore()
    {
        if (_canOpenStore && Input.GetAxis("Action") > 0)
        {
            Debug.Log("abrir loja");
        }
    }

    private void CatchCoin()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collide with npc
        if (collision.tag.Equals("Npc"))
        {
            _canOpenStore = true;
            Debug.Log("canOpenStore is true");
        } else if (collision.tag.Equals("Coin"))
        {
            Debug.Log("coin is here");
            //Debug.Log(Input.GetButtonDown)
            if (collision.isActiveAndEnabled && Input.GetButton("Action"))
            {
                Debug.Log("pegar moeda");
                Destroy(collision.gameObject);
            }
        }
    }
}
