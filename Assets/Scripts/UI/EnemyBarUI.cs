using UnityEngine;

public class EnemyBarUI : InteractionHandler
{
    [SerializeField] private InteractionHandler _enemy;
    [SerializeField] private UIBar _hpBar;
    [SerializeField] private UIBar _waterBar;

    protected override InteractionHandler InteractionObject => _enemy;

    private void Start()
    {
        _hpBar.SetMaxValue(_damageReceiver.StartValue);
        _waterBar.SetMaxValue(100);
        UpdateHP(_damageReceiver.Value);
        Water(_waterReceiver.Value);
    }

    protected override void UpdateHP(int hp) =>_hpBar.SetValue(hp);

    protected override void Fire(bool status) => _hpBar.SetColor(status ? Color.red : Color.white);

    protected override void Water(int water) => _waterBar.SetValue(water);
}