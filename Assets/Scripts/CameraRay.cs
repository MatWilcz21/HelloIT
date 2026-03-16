using UnityEngine;

public class CameraRay : MonoBehaviour
{

    [SerializeField] bool isAimingOnCube;

    [SerializeField] TargetCube targetCube;

    [SerializeField] float rayMaxRange;

    [SerializeField] GameObject targetCubePrefab;

    RaycastHit hit;

    int incrName;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetHit();
        SpawnCube();
    }

    void SpawnCube()
    {
        if (!GameInputSystem.gameInputs.Player.Jump.triggered)
        {
            return;
        }
        Debug.Log("Place Cube");
        GameObject cube = Instantiate(targetCubePrefab, hit.point + Vector3.up * 1.5f, Quaternion.identity);
        cube.name = string.Concat("Cube: ", incrName);
        incrName++;
    }

    void SetHit()
    {

        if (!Physics.Raycast(transform.position, transform.forward, out hit, rayMaxRange))
        {
            isAimingOnCube = false;
            return;
        }


        if (!GameInputSystem.gameInputs.Player.Attack.triggered)
        {
            return;
        }

        TryExtractTargetCube(hit.transform);

        void TryExtractTargetCube(Transform transform)
        {

            if (transform.TryGetComponent<TargetCube>(out TargetCube targetCubeX))
            {
                if (targetCube != null)
                    targetCube.SetSelectedMaterial(false);

                targetCube = targetCubeX;
                targetCube.SetSelectedMaterial(true);
            }
        }

    }
}

