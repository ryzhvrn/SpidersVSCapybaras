using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _turnSmoothTime = 0.1f;

    public static event Action<bool> PlayerMoving;

    private float _turnSmoothVelocity;
    private bool _isMoving = false;
    private bool _isKeyboardEnabled = true;

    private void OnEnable()
    {
        TipsButtonsController.DisableInput += OnDisableInput;
        TipsButtonsController.EnableInput += OnEnableInput;
    }

    private void OnDisable()
    {
        TipsButtonsController.DisableInput -= OnDisableInput;
        TipsButtonsController.EnableInput -= OnEnableInput;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (_isKeyboardEnabled == true)
        {
            if (direction.magnitude >= 0.1f)
            {
                _isMoving = true;
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                _controller.Move(moveDirection.normalized * _speed * Time.deltaTime);
            }
            else
            {
                _isMoving = false;
            }

            if (_isMoving)
            {
                PlayerMoving?.Invoke(_isMoving);
            }
            else
            {
                PlayerMoving?.Invoke(_isMoving);
            }
        }
        else
        {
            return;
        }
    }

    private void OnDisableInput()
    {
        _isKeyboardEnabled = false;
    }

    private void OnEnableInput()
    {
        _isKeyboardEnabled = true;
    }
}
