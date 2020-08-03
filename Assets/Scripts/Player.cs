using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _velocity = 5f;

    void Start()
    {
        transform.position = new Vector3(-6f, 0);
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, 0);

        transform.Translate(direction * _velocity * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.2f, 8.2f), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collide with npc
        if (collision.tag.Equals("Npc"))
        {
            Debug.Log("npc is here");
        }
    }
}
