using UnityEngine;

public class botoes : MonoBehaviour
{
    
    public string sceneName;
    public void ExitScene()
    {
        Gamemaneger.GameState currentState = Gamemaneger.Instance.GetCurrentState();

        if (currentState == Gamemaneger.GameState.MenuPrincipal)
        {
            Debug.LogWarning("Already in main menu!");
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            
        }
    }

    
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
