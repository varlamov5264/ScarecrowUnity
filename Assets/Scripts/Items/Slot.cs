using UnityEngine;

[System.Serializable]
public class Slot
{
    public IItem CurrentItem { get; private set; }
    public KeyCode keyCode;
    [SerializeField] private KeyCode _interactKey;
    [SerializeField] private Transform _target;

    public void SetItem(IItem item)
    {
        if (CurrentItem != null && CurrentItem.IsAvailible)
            CurrentItem.Drop();
        CurrentItem = item?.PickUp(_target, _interactKey);
    }
}