using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text moedasText;
    [SerializeField] private int moedas;

    private void OnEnable()
    {
        PlayerOM.OnCoinCollected += AddCoin;
    }

    private void OnDisable()
    {
        PlayerOM.OnCoinCollected -= AddCoin;
    }

    private void AddCoin(int moedas)
    {
        moedas ++;
        moedasText.text = moedas.ToString();
    }
}         
  