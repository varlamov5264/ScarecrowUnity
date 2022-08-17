using UnityEngine;

[RequireComponent(typeof(DamageReceiver), typeof(FireReceiver), typeof(WaterReceiver))]
public class Scarecrow : MonoBehaviour, IRestorable
{
    [SerializeField] private Animation _animation;
    [SerializeField] private AnimationClip _hitAnimation;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Color _fireColor;
    [SerializeField] private Color _waterColor;
    private DamageReceiver _damageReceiver;
    private FireReceiver _fireReceiver;
    private WaterReceiver _waterReceiver;
    private Color _defaultColor;

    private void Awake()
    {
        _damageReceiver = GetComponent<DamageReceiver>();
        _fireReceiver = GetComponent<FireReceiver>();
        _waterReceiver = GetComponent<WaterReceiver>();
    }

    private void OnEnable()
    {
        _damageReceiver.onUpdate += UpdateHP;
        _damageReceiver.onDead += Dead;
        _fireReceiver.onUpdate += Fire;
        _waterReceiver.onUpdate += Water;
    }

    private void Start() => _defaultColor = _meshRenderer.material.color;

    public void Restore() => _damageReceiver.Restore();

    private void UpdateHP(int hp) => _animation.Play(_hitAnimation.name);

    private void Dead() => Destroy(gameObject);

    private void Fire(bool status) =>
        _meshRenderer.material.color = status ? _fireColor : _defaultColor;

    private void Water(int water) =>
        _meshRenderer.material.color = water > 0 ? _waterColor : _defaultColor;

    private void OnDisable()
    {
        _damageReceiver.onUpdate -= UpdateHP;
        _damageReceiver.onDead -= Dead;
        _fireReceiver.onUpdate -= Fire;
        _waterReceiver.onUpdate -= Water;
    }
}