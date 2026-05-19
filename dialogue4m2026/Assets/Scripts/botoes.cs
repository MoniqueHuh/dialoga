using UnityEngine;

public class botoes : MonoBehaviour
{
    public string sceneName;
    
    public void ExitScene()
    {
        Gamemaneger.Instance.LoadScene(sceneName);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}

