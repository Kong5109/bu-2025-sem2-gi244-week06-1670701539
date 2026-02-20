using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam03 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;

    public bool enableAutoFireMode;
    public float autoFireInterval = 0.1f;

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private float nextTimeToFire;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");

        moveAction?.Enable();
        shootAction?.Enable();
        nextTimeToFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (shootAction.triggered)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
        
        float t = Time.time;
        if (enableAutoFireMode && t >= nextTimeToFire)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            nextTimeToFire = t + autoFireInterval;
        }
    }
}
