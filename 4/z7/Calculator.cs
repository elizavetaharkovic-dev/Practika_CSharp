class Calculator
{
    public double CalculateCircumference(double radius)
    {
        double C = 2* Math.PI * radius;
        return C;
    }
    public double CalculateCircumference(double length, double width)
    {
        double P = 2 * (length + width);
        return P;
    }
}