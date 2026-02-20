using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam06 : MonoBehaviour
{
    public enum MovementAxis
    {
        Horizontal,
        Vertical
    }

    public MovementAxis movementAxis;
    public float speed;

    private float horizontalInput;
    private float verticalInput;
    private InputAction moveAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction?.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        verticalInput = moveAction.ReadValue<Vector2>().y;

        if (movementAxis == MovementAxis.Horizontal)
        {
            transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);
        }
        else if (movementAxis == MovementAxis.Vertical)
        {
            transform.Translate(verticalInput * speed * Time.deltaTime * Vector3.forward);
        }
    }
}
