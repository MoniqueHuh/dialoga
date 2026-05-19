using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractButtonController : MonoBehaviour
{
    private Image button;
    private Vector3 interactPosition;
    private bool isInteractable;
    private Camera mainCamera;
    private RectTransform buttonRect;
    
    private void OnEnable()
    {
        InteractOM.OnInteractable += MudaBotao;
        InteractOM.InteractPosition += PegaPosicao;
    }

    private void OnDisable()
    {
        InteractOM.OnInteractable -= MudaBotao;
        InteractOM.InteractPosition -= PegaPosicao;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Image>();
        mainCamera = Camera.main;
        buttonRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteractable)
        {
            buttonRect.position = mainCamera.WorldToScreenPoint(interactPosition);
        }
    }
    
    private void MudaBotao(bool obj)
    {
        isInteractable = obj;
        button.color = isInteractable ? Color.white : Color.clear;
    }
    
    private void PegaPosicao(Vector3 obj)
    {
        interactPosition = obj;
    }
    
}
