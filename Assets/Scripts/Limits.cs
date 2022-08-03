using UnityEngine;

[System.Serializable]
public class Limits
{
    public Limits (int min, int max)
    {
        this.min = min;
        this.max = max;
    }

    public int min;
    public int max;

    public float Clamp(float value) => Mathf.Clamp(value, min, max);

    public int Clamp(int value) => Mathf.Clamp(value, min, max);
}