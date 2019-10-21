using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float speed = 0f;

    // Dependancies
    private Rigidbody rigidBody = null;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow))
        {
            float z = transform.position.z + (GetHorizontalInputAxis()) * (speed / 1000);
            float x = transform.position.x + (GetDepthInputAxis()) * (speed / 1000);
            Vector3 newCoordinates = new Vector3(
                x, 0, z);

            rigidBody.MovePosition(newCoordinates);
        }
    }

    private float GetHorizontalInputAxis()
    {
        return Input.GetAxis("Horizontal") * -1;
    }

    private float GetDepthInputAxis()
    {
        return Input.GetAxis("Vertical");
    }

    private Vector2 GetDirectionOfMovement()
    {
        return new Vector2(
            GetHorizontalInputAxis(),
            GetDepthInputAxis());
    }
}
