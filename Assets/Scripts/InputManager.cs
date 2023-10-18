using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControls playerControls;
    private Vector2 movementInput;
    public float horizontalInput;
    public float verticalInput;
    public float moveAmount;
    public bool sprint_input;

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerAction.Sprint.performed += i => sprint_input = true;
            playerControls.PlayerAction.Sprint.canceled += i => sprint_input = false;


        }
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    public void HandleAllInput()
    {
        HandleMovementInput();
    }
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        PlayerManager.Instance.playerAnimation.UpdateAnimatorValues(0, moveAmount);
    }

    private void HanndleSprinting()
    {
        if (sprint_input && moveAmount > 0.5)
        {
            PlayerManager.Instance.isSprinting = true;
        }

        else
        {
            PlayerManager.Instance.isSprinting = false;
        }
    }

}
