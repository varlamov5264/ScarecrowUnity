using UnityEngine;

public class WaterReceiver : Receiver<int>, IWaterReceivable
{
    [SerializeField] private Limits _limits = new Limits(0, 100);
    private FireReceiver _fireReceiver;

    public bool Status => Value > 0;

    protected override void Awake()
    {
        base.Awake();
        _fireReceiver = GetComponent<FireReceiver>();
    }

    public void Water(int water)
    {
        _value = _limits.Clamp(_value + water);
        if (_fireReceiver && water > 0)
            _fireReceiver.Fire(false);
        onUpdate?.Invoke(_value);
    }
}