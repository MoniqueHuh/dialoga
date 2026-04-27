using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Transition : MonoBehaviour
{
    [SerializeField] private Image transitionImage;
    [SerializeField] private float displayDuration = 2f;

    void Start()
    {
        
        if (transitionImage != null)
        {
            transitionImage.enabled = true;
        }

        
        StartCoroutine(ShowTransitionAndChangeScene());
    }
    
    private IEnumerator ShowTransitionAndChangeScene()
    {
        Debug.Log("Transition started...");
        
        // Aguarda o tempo especificado
        yield return new WaitForSeconds(displayDuration);

        Debug.Log("Transition complete, changing to Menu Principal...");
        
        // Solicita ao GameManager para mudar de estado
        Gamemaneger.Instance.ChangeGameState(Gamemaneger.GameState.MenuPrincipal);
    }
}