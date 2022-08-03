using UnityEngine;

public class ItemScannerUI : MonoBehaviour
{
    [SerializeField] private ItemScanner _itemScanner;
    [SerializeField] private GameObject _ui;

    private void OnEnable()
    {
        _itemScanner.onSelectedUpdate += SelectedUpdate;   
    }

    private void SelectedUpdate(IItem item)
    {
        _ui.SetActive(item != null);
    }

    private void OnDisable()
    {
        _itemScanner.onSelectedUpdate -= SelectedUpdate;
    }
}
