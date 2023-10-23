using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerController controller;

    [SerializeField]
    private float horizontalPositionMaxLimit;

    [SerializeField]
    private float horizontalPositionMinLimit;
    
    [SerializeField]
    private float verticalPositionMaxLimit;

    [SerializeField]
    private float verticalPositionMinLimit;

    [SerializeField]
    private float speed = 5;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (!controller.IsInControl)
            return;

        Move();
        LimitHorizontalMovement();
    }

    private void Move()
    {
        float horizontalInput = controller.InputHandler.GetHorizontalAxis();
        float verticalInput = controller.InputHandler.GetVerticalAxis();

        Vector3 direction = new Vector2(horizontalInput, verticalInput);
        transform.position += direction * Time.deltaTime * speed;
    }

    private void LimitHorizontalMovement()
    {
        if (transform.position.x > horizontalPositionMaxLimit)
            transform.position = new Vector2(horizontalPositionMaxLimit, transform.position.y);

        if (transform.position.x < horizontalPositionMinLimit)
            transform.position = new Vector2(horizontalPositionMinLimit, transform.position.y);
        
        if (transform.position.y > verticalPositionMaxLimit)
            transform.position = new Vector2(transform.position.x, verticalPositionMaxLimit);

        if (transform.position.y < verticalPositionMinLimit)
            transform.position = new Vector2(transform.position.x, verticalPositionMinLimit);
    }
}
