using System;
using UnityEngine;

public abstract class Receiver<T> : MonoBehaviour
{
    public Action<T> onUpdate;

    [SerializeField] protected T _value;
    private T _startValue;

    public T Value => _value;
    public T StartValue => _startValue;

    protected virtual void Awake() => _startValue = _value;

    public virtual void Restore() => _value = StartValue;
}
