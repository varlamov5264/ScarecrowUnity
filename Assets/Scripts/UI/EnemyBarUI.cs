using UnityEngine;

public class EnemyBarUI : MonoBehaviour
{
    [SerializeField] private Scarecrow _enemy;
    [SerializeField] private UIBar _hpBar;
    [SerializeField] private UIBar _waterBar;
    private DamageReceiver _damageReceiver;
    private FireReceiver _fireReceiver;
    private WaterReceiver _waterReceiver;

    private void Awake()
    {
        _damageReceiver = _enemy.GetComponent<DamageReceiver>();
        _fireReceiver = _enemy.GetComponent<FireReceiver>();
        _waterReceiver = _enemy.GetComponent<WaterReceiver>();
    }

    private void OnEnable()
    {
        if (_damageReceiver)
            _damageReceiver.onUpdate += UpdateHP;
        if (_fireReceiver)
            _fireReceiver.onUpdate += Fire;
        if (_waterReceiver)
            _waterReceiver.onUpdate += Water;
    }

    private void Start()
    {
        _hpBar.SetMaxValue(_damageReceiver.StartValue);
        _waterBar.SetMaxValue(100);
        UpdateHP(_damageReceiver.Value);
        Water(_waterReceiver.Value);
    }

    private void UpdateHP(int hp) =>_hpBar.SetValue(hp);

    private void Fire(bool status) => _hpBar.SetColor(status ? Color.red : Color.white);

    private void Water(int water) => _waterBar.SetValue(water);

    private void OnDisable()
    {
        if (_damageReceiver)
            _damageReceiver.onUpdate -= UpdateHP;
        if (_fireReceiver)
            _fireReceiver.onUpdate -= Fire;
        if (_waterReceiver)
            _waterReceiver.onUpdate -= Water;
    }
}