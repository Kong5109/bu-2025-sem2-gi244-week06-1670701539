using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam02 : MonoBehaviour
{
    public float speed;
    public float zRange = 10;
    public GameObject projectilePrefab;

    private float verticalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");

        moveAction?.Enable();
        shootAction?.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = moveAction.ReadValue<Vector2>().y;
        transform.Translate(Vector3.left * (verticalInput * speed * Time.deltaTime));

        if (shootAction.WasPressedThisFrame())
        {
            Instantiate(projectilePrefab, transform.position, this.transform.rotation);
        }
    }
}
