using System.Collections;
using UnityEngine;

public class FireReceiver : Receiver<bool>, IFlammable
{
    public bool Status { get; private set; }

    [SerializeField] private int _burningSeconds = 10;
    [SerializeField] private int _burningDamagePerSecond = 5;
    private DamageReceiver _damageReceiver;
    private WaterReceiver _waterReceiver;
    private Coroutine _fireAction;

    protected override void Awake()
    {
        base.Awake();
        _damageReceiver = GetComponent<DamageReceiver>();
        _waterReceiver = GetComponent<WaterReceiver>();
    }

    public void Burn()
    {
        if (_damageReceiver)
            _damageReceiver.Damage(1);
        if (_waterReceiver && _waterReceiver.Status)
            _waterReceiver.Water(-1);
        else
            Fire(true);
    }

    public void Fire(bool status)
    {
        _value = status;
        if (_fireAction != null)
            StopCoroutine(_fireAction);
        if (_value)
            _fireAction = StartCoroutine(FireAction());
        onUpdate?.Invoke(_value);
    }

    private IEnumerator FireAction()
    {
        int seconds = 0;
        var waitSecond = new WaitForSeconds(1);
        while (seconds != _burningSeconds)
        {
            seconds++;
            if (_damageReceiver)
                _damageReceiver.Damage(_burningDamagePerSecond);
            yield return waitSecond;
        }
        Fire(false);
    }
}
