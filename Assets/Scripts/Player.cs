using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _velocity = 5f;

    private float _playerYPosition = -2.5f;

    private Inventory _playerInventory;

    private Wallet _playerWallet;

    void Start()
    {
        transform.position = new Vector3(-6f, _playerYPosition);
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, _playerYPosition);

        if (_velocity != 0)
        {
            transform.Translate(direction * _velocity * Time.deltaTime);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.2f, 8.2f), _playerYPosition);
    }
}
