using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClimbProvider : MonoBehaviour
{
    public static event Action ClimbActive;
    public static event Action ClimbInActive;

    public CharacterController characterController;
    public PlayerLocomotion locomotion;
    public InputActionProperty velocityRight;
    public InputActionProperty velocityLeft;

    private bool _rightActive = false;
    private bool _leftActive = false;

    private Vector3 storedVelocity = Vector3.zero;

    private void Start()
    {
        XRDirectClimbInteractor.ClimbHandActivated += HandActivated;
        XRDirectClimbInteractor.ClimbHandDeactivated += HandDeactivated;
        locomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnDestroy()
    {
        XRDirectClimbInteractor.ClimbHandActivated -= HandActivated;
        XRDirectClimbInteractor.ClimbHandDeactivated -= HandDeactivated;
    }

    private void HandActivated(string _controllerName)
    {
        if (_controllerName == "LeftHand Controller")
        {
            _leftActive = true;
            _rightActive = false;
        }
        else
        {
            _leftActive = false;
            _rightActive = true;
        }

        ClimbActive?.Invoke();
    }

    private void HandDeactivated(string _controllerName)
    {

        if (_rightActive && _controllerName == "RightHand Controller")
        {
            _rightActive = false;
            ClimbInActive?.Invoke();
            ApplyVelocity();
        }
        else if (_leftActive && _controllerName == "LeftHand Controller")
        {
            _leftActive = false;
            ClimbInActive?.Invoke();
            ApplyVelocity();
        }
    }

    private void ApplyVelocity()
    {
        if (!_leftActive && !_rightActive)
        {
            locomotion.velocity = -storedVelocity;
            storedVelocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        if (_rightActive || _leftActive)
        {
            Climb();
        }
    }

    private void Climb()
    {
        Vector3 velocity = _leftActive ? velocityLeft.action.ReadValue<Vector3>() : velocityRight.action.ReadValue<Vector3>();
        storedVelocity = velocity;

        characterController.Move(characterController.transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}