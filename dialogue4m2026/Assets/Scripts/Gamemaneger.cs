using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Gamemaneger : MonoBehaviour
{
    public static Gamemaneger Instance { get; private set; }

    public enum GameState
    {
        Iniciando,
        MenuPrincipal,
        Gameplay
    }

    private GameState currentState = GameState.Iniciando;

    private PlayerInput playerInput;

    void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    
    void Start()
    {
        
        playerInput = FindObjectOfType<PlayerInput>();
        if (playerInput != null)
        {
            playerInput.enabled = true;
        }

        
        ChangeState(GameState.Iniciando);
      
        SceneManager.LoadScene("_Boot");
        ChangeState(GameState.MenuPrincipal);
    }

    
    void Update()
    {
        
    }

    public void RequestSceneChange(string sceneName)
    {
        bool allowChange = false;

        switch (currentState)
        {
            case GameState.Iniciando:
                if (sceneName == "_Boot") // Assuming _Boot is the menu scene
                    allowChange = true;
                break;
            case GameState.MenuPrincipal:
                if (sceneName == "SampleScene") // Assuming SampleScene is Gameplay
                    allowChange = true;
                break;
            case GameState.Gameplay:
                if (sceneName == "_Boot")
                    allowChange = true;
                break;
        }

        if (allowChange)
        {
            SceneManager.LoadScene(sceneName);
            // Update state based on scene
            if (sceneName == "_Boot")
                ChangeState(GameState.Iniciando);
            else if (sceneName == "SampleScene")
                ChangeState(GameState.Gameplay);
        }
        else
        {
            Debug.LogWarning("Scene change not allowed from current state: " + currentState);
        }
    }

    private void ChangeState(GameState newState)
    {
        currentState = newState;
        Debug.Log("Game state changed to: " + currentState);
    }

    public GameState GetCurrentState()
    {
        return currentState;
    }
}
