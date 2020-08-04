using UnityEngine;

public class StoreItem : MonoBehaviour
{
    [SerializeField]
    private int _id;
    [SerializeField]
    private string _name;
    [SerializeField]
    private int _price;
    [SerializeField]
    private Sprite _photo;

    void Start()
    {
    }

    void Update()
    {

    }

    public int Id => _id;
}
