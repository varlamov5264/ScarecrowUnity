using System;
using UnityEngine;

public class ItemScanner : MonoBehaviour
{
    public Action<IItem> onSelectedUpdate;
    [SerializeField] private LayerMask _itemLayer;
    [SerializeField] private float _distance = 3;
    [SerializeField] private Slot[] _slots;
    private IItem _selectedItem;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, _distance, _itemLayer))
        {
            if (hit.transform.TryGetComponent(out IItem item) && !item.InHand && item.IsAvailible)
            {
                _selectedItem = item;
                onSelectedUpdate?.Invoke(item);
            }
        }
        else
        {
            _selectedItem = null;
            onSelectedUpdate?.Invoke(null);
        }
        foreach (var slot in _slots)
        {
            if (Input.GetKeyDown(slot.keyCode))
                slot.SetItem(_selectedItem);
        }
    }
}