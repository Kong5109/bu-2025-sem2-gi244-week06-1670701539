using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam05 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;


    // Exam 05 ...
    public int maxBulletCount = 10;
    public float bulletRegenerateCooldown = 1f;

    private int bulletLeftToShoot = 0;
    private float timeToFullReload = 0;
    // ...

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");

        moveAction?.Enable();
        shootAction?.Enable();
        timeToFullReload = Time.time;
        bulletLeftToShoot = maxBulletCount;
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


        float t = Time.time;
        if (bulletLeftToShoot > 0)
        {
            if (shootAction.triggered)
            {
                Instantiate(projectilePrefab, transform.position, transform.rotation);
                bulletLeftToShoot--;
                timeToFullReload = t + bulletRegenerateCooldown;
            }
        }
        else if (t >= timeToFullReload)
        {
            bulletLeftToShoot = maxBulletCount;
        }
    }
}
