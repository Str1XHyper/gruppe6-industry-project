using UnityEngine;
using UnityEngine.InputSystem;

public class InputProcessor : MonoBehaviour
{
    [HideInInspector] public bool screenPressed;
    public void OnMove(InputAction.CallbackContext ctx)
    {
        screenPressed = ctx.performed;
    }
}
