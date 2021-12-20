using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    #region Singleton
    public static InputManager instance;

    private PlayerControls playerControls;
         
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }

        playerControls = new PlayerControls();
    }
    #endregion

    public void OnEnable()
    {
        playerControls.Enable();
    }

    public void OnDisable()
    {
        playerControls.Disable();
    }

    public bool OnCloseGame()
    {
        return playerControls.UI.CloseGame.triggered; 
    }

    #region Block Inputs

    public bool GetBlockInteractStart()
    {
        return playerControls.Blocks.Interact.triggered;
    }

    public bool GetBlockInteractHolding()
    {
        return playerControls.Blocks.Interact.ReadValue<float>() > 0;
    }


    #endregion Block

    #region Player Movement

    public bool GetScreenPressed()
    {
        return playerControls.Player.Move.triggered;
    }

    #endregion

    public string DoAThing()
    {
        return "Doing the thing";
    }

}
