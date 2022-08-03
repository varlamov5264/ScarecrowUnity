using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    [Flags]
    public enum Axis
    {
        X = 1 << 1,
        Y = 1 << 2,
        Z = 1 << 3,
    }

    [SerializeField] private Axis _axis;
    [SerializeField] private Vector3 _shift;
    private Camera _camera;

    private void Update()
    {
        if (_camera == null)
            _camera = Camera.main;
        Vector3 relativePos = _camera.transform.position - transform.position;
        var rotation = Quaternion.LookRotation(relativePos, Vector3.up).eulerAngles;
        if (!_axis.HasFlag(Axis.X))
            rotation.x = 0;
        if (!_axis.HasFlag(Axis.Y))
            rotation.y = 0;
        if (!_axis.HasFlag(Axis.Z))
            rotation.z = 0;
        transform.eulerAngles = rotation + _shift;
    }
}
