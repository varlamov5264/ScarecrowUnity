using System;

public class DamageReceiver : Receiver<int>, IDamageable
{
    public Action onDead;
    private FireReceiver _fireReceiver;
    private WaterReceiver _waterReceiver;

    protected override void Awake()
    {
        base.Awake();
        _fireReceiver = GetComponent<FireReceiver>();
        _waterReceiver = GetComponent<WaterReceiver>();
    }

    public void Damage(int damage)
    {
        if (_waterReceiver && _waterReceiver.Status)
            damage -= 10;
        if (_fireReceiver && _fireReceiver.Status)
            damage += 10;
        if (damage > 0)
        {
            _value -= damage;
            onUpdate?.Invoke(Value);
            if (_value <= 0)
                onDead?.Invoke();
        }
    }

    public override void Restore()
    {
        base.Restore();
        onUpdate?.Invoke(Value);
    }
}