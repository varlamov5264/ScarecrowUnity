using UnityEngine;

public class UIBar : MonoBehaviour
{
    [SerializeField] private string _textMask;
    [SerializeField] private TextMesh _label;
    [SerializeField] private SpriteRenderer _bar;
    private int _maxValue;
    private Vector2 _startBarPosition;
    private Vector2 _startBarSize;

    private void Awake()
    {
        _startBarPosition = _bar.transform.localPosition;
        _startBarSize = _bar.size;
    }

    public void SetMaxValue(int maxValue) => _maxValue = maxValue;

    public void SetValue(int value)
    {
        _label.text = string.Format(_textMask, value);
        var percent = (float)value / (float)_maxValue;
        _bar.size = _startBarSize.SetX(_startBarSize.x * percent);
        var diff = _startBarSize.x - _bar.size.x;
        _bar.transform.localPosition = _startBarPosition.PlusX(-diff / 2);
    }

    public void SetColor(Color color) => _bar.color = color;
}
