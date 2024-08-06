using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerControls playerInput;
    private PlayerControls.BasicControlsActions basicControls;
    private PlayerMotor playerMotor;


    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerControls();
        basicControls = playerInput.BasicControls;

        playerMotor = GetComponent<PlayerMotor>();
    }
    
    private void OnEnable()
    {
        basicControls.Enable();
    }

    private void OnDisable()
    {
        basicControls.Disable();
    }
    void Update()
    {
        playerMotor.Move(basicControls.Movement.ReadValue<Vector2>());
    }

}
