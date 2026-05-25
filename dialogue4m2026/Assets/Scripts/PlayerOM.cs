using System;

public static class PlayerOM
{
    // Evento de moedas
    public static Action<int> OnCoinCollected;

    public static void CollectCoin(int currentCoins)
    {
        OnCoinCollected?.Invoke(currentCoins);
    }
}