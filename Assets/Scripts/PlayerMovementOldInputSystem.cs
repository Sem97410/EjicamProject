using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementOldInputSystem : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0);
        transform.Translate(movement);
    }
}
