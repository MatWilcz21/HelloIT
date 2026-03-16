using UnityEngine;
using UnityEngine.InputSystem;

public class AimCamera : MonoBehaviour
{
    [SerializeField] float aimSpeed;

    float x,y;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {


        CameraAim();
    }

    void CameraAim()
    {

        float verticalRange = 15;

        float horizontalRange = 45;

        x -= GameInputSystem.gameInputs.Player.Look.ReadValue<Vector2>().y * aimSpeed * 0.01f;
        y += GameInputSystem.gameInputs.Player.Look.ReadValue<Vector2>().x * aimSpeed * 0.01f;
        x = Mathf.Clamp(x, -verticalRange, verticalRange);
        y = Mathf.Clamp(y, -horizontalRange, horizontalRange);
        transform.rotation = Quaternion.Euler(x + 30, y, 0);

    }
}
