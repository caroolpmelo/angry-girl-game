using UnityEngine;

public class StoreItem : MonoBehaviour
{
    [SerializeField]
    private int _id;
    [SerializeField]
    private string _name;
    [SerializeField]
    private Sprite _photo;
    
    public Object Coin { get;  set; }

    public bool IsSelected { get;  set; }

    public int Id => _id;
}
