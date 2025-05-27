public class Fraction
{
    private int _top;
    private int _bottom;

    // No-parameter constructor (1/1)
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // One-parameter constructor (top/1)
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Two-parameter constructor (top/bottom)
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter and Setter for Top
    public int GetTop()
    {
        return _top;
    }
    public void SetTop(int value)
    {
        _top = value;
    }

    // Getter and Setter for Bottom
    public int GetBottom()
    {
        return _bottom;
    }
    public void SetBottom(int value)
    {
        _bottom = value;
    }

    // Returns string representation "top/bottom"
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Returns decimal value
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}