using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{ 
    [SerializeField] private GameObject _inventory;

    public static GameManager _instance;

    private void Start()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ToggleInventory()
    {
        _inventory.SetActive(!_inventory.activeSelf);
    }
}
