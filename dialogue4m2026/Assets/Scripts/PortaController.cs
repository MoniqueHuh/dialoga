using System;
using UnityEngine;

public class PortaController : MonoBehaviour
{
    private Animator anim;
    private bool isOpen;
    private bool isInteractable;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isInteractable)
        {
            InteractOM.OnInteract += AbrirPorta;
            isInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && isInteractable)
        {
            InteractOM.OnInteract -= AbrirPorta;
            isInteractable = false;
        }
    }

    private void AbrirPorta()
    {
        if (!isOpen)
        {
            anim.StopPlayback();
            anim.Play("PortaAbrindo");
            isOpen = true;
        }
        else
        {
            anim.StopPlayback();
            anim.Play("PortaFechando");
            isOpen = false;
        }
    }
}
