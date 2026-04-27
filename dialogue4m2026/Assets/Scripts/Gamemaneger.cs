using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Gamemaneger : MonoBehaviour
{
    public static Gamemaneger Instance { get; private set; }

    public enum GameState
    {
        Iniciando,
        MenuPrincipal,
        Gameplay
    }

    // Mapeamento de Estados para nomes de cenas
    private Dictionary<GameState, string> stateToScene = new Dictionary<GameState, string>()
    {
        { GameState.Iniciando, "_Boot" },
        { GameState.MenuPrincipal, "_Boot" },
        { GameState.Gameplay, "SampleScene" }
    };

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
        DontDestroyOnLoad(gameObject);
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

    /// <summary>
    /// Método público para mudar o estado do jogo
    /// Carrega automaticamente a cena associada ao novo estado
    /// </summary>
    public void ChangeGameState(GameState newState)
    {
        if (currentState == newState) return;

        // Carrega a cena associada ao novo estado
        if (stateToScene.TryGetValue(newState, out string sceneName))
        {
            LoadScene(sceneName);
            ChangeState(newState);
        }
        else
        {
            Debug.LogError($"State {newState} has no associated scene!");
        }
    }

    /// <summary>
    /// Método público para outros scripts solicitarem mudança de cena
    /// Valida se a mudança é permitida no estado atual
    /// </summary>
    public void RequestSceneChange(string sceneName)
    {
        bool allowChange = false;

        switch (currentState)
        {
            case GameState.Iniciando:
                if (sceneName == "_Boot")
                    allowChange = true;
                break;
            case GameState.MenuPrincipal:
                if (sceneName == "SampleScene")
                    allowChange = true;
                break;
            case GameState.Gameplay:
                if (sceneName == "_Boot")
                    allowChange = true;
                break;
        }

        if (allowChange)
        {
            LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning($"Scene change not allowed from current state: {currentState}");
        }
    }

    /// <summary>
    /// Método privado que efetivamente carrega a cena
    /// Apenas o GameManager pode acessar o SceneManager
    /// </summary>
    public void LoadScene(string sceneName)
    {
        Debug.Log($"Loading scene: {sceneName}");
        SceneManager.LoadScene(sceneName);

        // Atualiza o estado baseado na cena carregada
        foreach (var kvp in stateToScene)
        {
            if (kvp.Value == sceneName)
            {
                ChangeState(kvp.Key);
                break;
            }
        }
    }

    private void ChangeState(GameState newState)
    {
        currentState = newState;
        Debug.Log($"Game state changed to: {currentState}");
    }

    public GameState GetCurrentState()
    {
        return currentState;
    }

    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
