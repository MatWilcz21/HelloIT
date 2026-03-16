using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputSystem : MonoBehaviour
{

    public static InputSystem_Actions gameInputs { get; private set; }

    void Start()
    {
        gameInputs = new InputSystem_Actions();
        gameInputs.Enable();
    }


}
