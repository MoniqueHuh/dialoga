using System;

public static class PlayerOM
{
    // Evento de moedas
    public static event Action OnCoinCollected;

    public static void CollectCoin()
    {
        OnCoinCollected?.Invoke();
    }
}