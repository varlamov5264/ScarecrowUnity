using System;
using UnityEngine;

[RequireComponent(typeof(DamageReceiver), typeof(FireReceiver), typeof(WaterReceiver))]
public class Scarecrow : InteractionHandler
{
    [SerializeField] private Animation _animation;
    [SerializeField] private AnimationClip _hitAnimation;

    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Color _fireColor;
    [SerializeField] private Color _waterColor;
    private Color _defaultColor;

    private void Start()
    {
        _defaultColor = _meshRenderer.material.color;
    }

    protected override void UpdateHP(int hp) => _animation.Play(_hitAnimation.name);

    protected override void Dead() => Destroy(gameObject);

    protected override void Fire(bool status) =>
        _meshRenderer.material.color = status ? _fireColor : _defaultColor;

    protected override void Water(int water) =>
        _meshRenderer.material.color = water > 0 ? _waterColor : _defaultColor;
}