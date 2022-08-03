using UnityEngine;

public abstract class InteractionHandler : MonoBehaviour, IRestorable
{
    protected DamageReceiver _damageReceiver;
    protected FireReceiver _fireReceiver;
    protected WaterReceiver _waterReceiver;

    protected virtual InteractionHandler InteractionObject => this;

    private void Awake()
    {
        _damageReceiver = InteractionObject.GetComponent<DamageReceiver>();
        _fireReceiver = InteractionObject.GetComponent<FireReceiver>();
        _waterReceiver = InteractionObject.GetComponent<WaterReceiver>();
    }

    private void OnEnable()
    {
        if (_damageReceiver)
        {
            _damageReceiver.onUpdate += UpdateHP;
            _damageReceiver.onDead += Dead;
        }
        if (_fireReceiver)
            _fireReceiver.onUpdate += Fire;
        if (_waterReceiver)
            _waterReceiver.onUpdate += Water;
    }

    public void Restore() => _damageReceiver.Restore();

    protected virtual void UpdateHP(int hp) { }

    protected virtual void Dead() { }

    protected virtual void Fire(bool status) { }

    protected virtual void Water(int water) { }

    private void OnDisable()
    {
        if (_damageReceiver)
        {
            _damageReceiver.onUpdate -= UpdateHP;
            _damageReceiver.onDead -= Dead;
        }
        if (_fireReceiver)
            _fireReceiver.onUpdate -= Fire;
        if (_waterReceiver)
            _waterReceiver.onUpdate -= Water;
    }
}