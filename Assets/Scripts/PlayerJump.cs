using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    public InputAction jumpAction;

    private void OnEnable()
    {
        // Activer l'action d'entr�e
        jumpAction.Enable();

        // D�finir le callback pour g�rer tous les types de sauts
        jumpAction.performed += ctx => HandleJump(ctx);
    }

    private void OnDisable()
    {
        // D�sactiver l'action d'entr�e
        jumpAction.Disable();

        // Retirer le callback lors de la d�sactivation
        jumpAction.performed -= ctx => HandleJump(ctx);
    }
    private void HandleJump(InputAction.CallbackContext context)
    {
        Debug.Log("Bouton jump a �t� pr�ss�");
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
