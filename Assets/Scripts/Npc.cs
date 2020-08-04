using UnityEngine;

public class Npc : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(6f, -2f);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Debug.Log("npc is here");
        }
    }
}
