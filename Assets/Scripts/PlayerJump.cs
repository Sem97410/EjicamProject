using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    public InputAction jumpAction;

    private void OnEnable()
    {
        // Activer l'action d'entrée
        jumpAction.Enable();

        // Définir le callback pour gérer tous les types de sauts
        jumpAction.performed += ctx => HandleJump(ctx);
    }

    private void OnDisable()
    {
        // Désactiver l'action d'entrée
        jumpAction.Disable();

        // Retirer le callback lors de la désactivation
        jumpAction.performed -= ctx => HandleJump(ctx);
    }
    private void HandleJump(InputAction.CallbackContext context)
    {
        Debug.Log("Bouton jump a été préssé");
        int tapCount = context.action.ReadValue<int>();

        switch (tapCount)
        {
            case 1:
                Debug.Log("Simple Jump");
                break;
            case 2:
                Debug.Log("Double Jump");
                break;
            case 3:
                Debug.Log("Tiple Jump");
                break;
            default:
                break;
        }


    }
}
