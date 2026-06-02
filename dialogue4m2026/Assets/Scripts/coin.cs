using UnityEngine;

public class Coin : MonoBehaviour
{
    
    private int coins = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if(player != null)
            {
                AddCoin();
                PlayerOM.CollectCoin();
            }

            Destroy(gameObject);
        }
    }
    

    public void AddCoin()
    {        

        Debug.Log("Moedas: " + coins);


        PlayerOM.CollectCoin();
    }
}

