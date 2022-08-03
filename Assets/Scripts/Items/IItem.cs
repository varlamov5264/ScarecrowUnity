using UnityEngine;

public interface IItem
{
    public bool InHand { get; }
    public bool IsAvailible { get; }
    public IItem PickUp(Transform target, KeyCode interactKey);
    public void Drop();
}