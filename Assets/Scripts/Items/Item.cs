using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour, IItem
{
    public enum Type
    {
        Default,
        Copyable
    }

    [SerializeField] private Type _type;
    protected bool _action { get; private set; }
    protected KeyCode _interactKey;
    protected bool _isAvailible = true;
    private bool _inHand;
    private Coroutine _lerpToZero;

    public bool InHand => _inHand;

    public bool IsAvailible => _isAvailible;

    public virtual void Drop()
    {
        if (_type == Type.Default)
        {
            DropFromHand();
        }
        else if (_type == Type.Copyable)
        {
            Destroy(gameObject);
        }
    }

    protected void DropFromHand()
    {
        _action = false;
        _inHand = false;
        transform.SetParent(null);
        gameObject.AddComponent<Rigidbody>();
    }

    public virtual IItem PickUp(Transform target, KeyCode interactKey)
    {
        if (_type == Type.Default)
        {
            SetPreference(target, interactKey);
            return this;
        }
        else if (_type == Type.Copyable)
        {
            var item = Instantiate(this);
            item.SetPreference(target, interactKey);
            return item;
        }
        return null;
    }

    public void SetPreference(Transform target, KeyCode interactKey)
    {
        _inHand = true;
        _interactKey = interactKey;
        if (TryGetComponent(out Rigidbody rigidbody))
            Destroy(rigidbody);
        transform.SetParent(target);
        if (_lerpToZero != null)
            StopCoroutine(_lerpToZero);
        _lerpToZero = StartCoroutine(LerpToZero());
    }

    protected IEnumerator LerpToZero()
    {
        var timer = 0f;
        var startPosition = transform.localPosition;
        var startRotation = transform.localRotation;
        while (timer != 1)
        {
            timer = Mathf.MoveTowards(timer, 1, Time.deltaTime * Constants.SpeedLerpItem);
            transform.localPosition = Vector3.Lerp(startPosition, Vector3.zero, timer);
            transform.localRotation = Quaternion.Lerp(startRotation, Quaternion.identity, timer);
            yield return null;
        }
        _action = true;
    }
}