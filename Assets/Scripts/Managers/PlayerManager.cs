public static class PlayerManager
{
    private static uint availableGil = 0;

    public static uint AvailableGil
    {
        get { return availableGil; }
    }

    public static void IncreaseGil(uint amount)
    {
        availableGil += amount;
    }

    public static bool TryReduceGil(uint amount, out uint actualAmount)
    {
        if ((availableGil -= amount) < 0)
        {
            ReduceGil(availableGil);
            actualAmount = availableGil;
            return false;
        }

        ReduceGil(amount);
        actualAmount = amount;
        return true;
    }

    private static void ReduceGil(uint amount)
    {
        availableGil -= amount;
    }
}