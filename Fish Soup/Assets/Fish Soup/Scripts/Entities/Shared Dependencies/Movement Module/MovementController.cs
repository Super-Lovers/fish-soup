using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float speed = 0f;
    [Range(0, 100)]
    [SerializeField] private float maxSpeed = 0f;

    // Dependancies
    private Rigidbody rigidBody = null;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 newCoordinates = new Vector3(
            GetHorizontalInputAxis(), 0, GetVerticalInputAxis());

        rigidBody.MovePosition(newCoordinates);
    }

    private float GetHorizontalInputAxis()
    {
        return Input.GetAxis("Horizontal");
    }

    private float GetVerticalInputAxis()
    {
        return Input.GetAxis("Vertical");
    }

    private Vector2 GetDirectionOfMovement()
    {
        return new Vector2(
            GetHorizontalInputAxis(),
            GetVerticalInputAxis());
    }

    private float ConvertAxisToRealSpeed(float axis)
    {
        float newSpeed = (axis * speed) * Time.deltaTime;
        return Mathf.Clamp(newSpeed, 0, this.maxSpeed);
    }
}
