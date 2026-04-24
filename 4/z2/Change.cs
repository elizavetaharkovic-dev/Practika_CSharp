class Change
{
    public void ShiftRight3(ref int A, ref int B, ref int C)
    {
        int C1 = C;
        C = B;
        B = A;
        A = C1;
    }
}