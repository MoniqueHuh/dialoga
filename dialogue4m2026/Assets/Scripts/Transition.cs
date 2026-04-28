using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Transition : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private float displayDuration = 2f;

    void Start()
    {
        Invoke("Mov", displayDuration);
    }

    public void Mov()
    {
        Gamemaneger.Instance.LoadScene(sceneName);
        
    }
}