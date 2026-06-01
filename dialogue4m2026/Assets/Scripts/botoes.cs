using UnityEngine;

public class botoes : MonoBehaviour
{
    public string sceneName;
    public string addSceneName;
    
    public void ExitScene()
    {
        Gamemaneger.Instance.LoadScene(sceneName);
        Gamemaneger.Instance.LoadAddtive(addSceneName);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}

