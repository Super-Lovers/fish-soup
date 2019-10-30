using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float speed = 0f;

    // Dependancies
    private Rigidbody rigidBody = null;

    /// <summary>
    /// Temporary solution to the movement optimization problem.
    /// </summary>
    [SerializeField] private Transform Up = null;
    [SerializeField] private Transform Down = null;
    [SerializeField] private Transform Left = null;
    [SerializeField] private Transform Right = null;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Temporary solution to the movement optimization problem.
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position = Vector3.MoveTowards(transform.position, Up.transform.position, speed / 1000);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position = Vector3.MoveTowards(transform.position, Down.transform.position, speed / 1000);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position = Vector3.MoveTowards(transform.position, Left.transform.position, speed / 1000);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position = Vector3.MoveTowards(transform.position, Right.transform.position, speed / 1000);
            }
        }

        // Optimized solution to the movement optimization problem.
        //if (Input.anyKey)
        //{
        //    Vector3 newCoordinates = transform.position;

        //    if (GetDepthInputAxis() == 0 || GetHorizontalInputAxis() == 0)
        //    {
        //        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        //        {
        //            float x = transform.position.x - GetDepthInputAxis() * (speed / 1000);
        //            float z = transform.position.z - GetDepthInputAxis() * (speed / 1000);
        //            newCoordinates = new Vector3(x, 0, z);
        //        }

        //        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        //        {
        //            float z = transform.position.z - GetHorizontalInputAxis() * (speed / 1000);
        //            float x = transform.position.x + GetHorizontalInputAxis() * (speed / 1000);
        //            newCoordinates = new Vector3(x, 0, z);
        //        }
        //    }
        //    else
        //    {
        //        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        //        {
        //            float x = transform.position.x - GetDepthInputAxis() * (speed / 1000);
        //            float z = transform.position.z - (GetDepthInputAxis() + GetDepthInputAxis()) * (speed / 1000);
        //            newCoordinates = new Vector3(x, 0, z);
        //        }

        //        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        //        {
        //            float x = transform.position.x - (GetDepthInputAxis() + GetDepthInputAxis()) * (speed / 1000);
        //            float z = transform.position.z - GetDepthInputAxis() * (speed / 1000);
        //            newCoordinates = new Vector3(x, 0, z);
        //        }

        //        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        //        {
        //            float x = transform.position.x - GetDepthInputAxis() * (speed / 1000);
        //            float z = transform.position.z - (GetDepthInputAxis() - GetDepthInputAxis()) * (speed / 1000);
        //            newCoordinates = new Vector3(x, 0, z);
        //        }

        //        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        //        {
        //            float x = transform.position.x - (GetDepthInputAxis() - GetDepthInputAxis()) * (speed / 1000);
        //            float z = transform.position.z - GetDepthInputAxis() * (speed / 1000);
        //            newCoordinates = new Vector3(x, 0, z);
        //        }
        //    }

        //    rigidBody.MovePosition(new Vector3(newCoordinates.x, 0, newCoordinates.z));
        //}
    }

    private float GetDepthInputAxis()
    {
        return Input.GetAxis("Vertical") * -1;
    }

    private float GetHorizontalInputAxis()
    {
        return Input.GetAxis("Horizontal");
    }

    private Vector2 GetDirectionOfMovement()
    {
        return new Vector2(
            GetHorizontalInputAxis(),
            GetDepthInputAxis());
    }
}
