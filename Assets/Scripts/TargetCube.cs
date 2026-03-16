using UnityEngine;

public class TargetCube : MonoBehaviour
{

    [SerializeField] Material SelMaterial;
    [SerializeField] Material UnSelMaterial;

    Renderer selfRenderer;
    Rigidbody rb;

    [SerializeField] float force;
    [SerializeField] float forcePosition;

    bool isSelected;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        selfRenderer = GetComponent<Renderer>();
        SetSelectedMaterial(false);
    }

    void Update()
    {
        if (!isSelected) return;

        Vector3 _force = new Vector3(GameInputSystem.gameInputs.Player.Move.ReadValue<Vector2>().x, 0, GameInputSystem.gameInputs.Player.Move.ReadValue<Vector2>().y);
        _force = _force.normalized;
        _force *= force;
        _force *= rb.mass;
        

            rb.AddForceAtPosition(_force * Time.deltaTime, transform.position + Vector3.up * forcePosition);
    }

    public void SetSelectedMaterial(bool sel)
    {
        isSelected = sel;

        if (isSelected)
            selfRenderer.material = SelMaterial;
        else
            selfRenderer.material = UnSelMaterial;
    }
}
