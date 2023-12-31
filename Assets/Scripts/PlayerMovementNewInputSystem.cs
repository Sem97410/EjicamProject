using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementNewInputSystem : MonoBehaviour
{
    private CustomInput _input = null;
    private Vector3 _moveVector = Vector3.zero;
    private Rigidbody _rb = null;
    [SerializeField] private float _moveSpeed = 10f;

    private void Awake()
    {
        _input = new CustomInput();
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.usualPlayerMovement.Movement.performed += OnMovementPerformed;
        _input.usualPlayerMovement.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.usualPlayerMovement.Movement.performed -= OnMovementPerformed;
        _input.usualPlayerMovement.Movement.canceled -= OnMovementCancelled;
    }

    private void FixedUpdate()
    {
        //_moveVector.y = 0f;
       _rb.velocity = _moveVector * _moveSpeed;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        _moveVector = value.ReadValue<Vector3>();
        Debug.Log("Movement performed on device: " + value.control.device.displayName);
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        _moveVector = Vector3.zero;
        Debug.Log("Movement cancelled on device: " + value.control.device.displayName);

    }
}
