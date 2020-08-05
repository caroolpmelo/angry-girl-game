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

    [SerializeField]
    private bool _isSelected = false;
    [SerializeField]
    private GameObject _selector;

    void Start()
    {
        
    }

    void Update()
    {
        if (_isSelected && !_selector.activeSelf)
        {
            _selector.SetActive(true);
        }
        else if (!_isSelected && _selector.activeSelf)
        {
            _selector.SetActive(false);
        }
    }

    public int Id => _id;
}
