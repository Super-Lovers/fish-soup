using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float speed = 0f;
    private bool isEntityPlayer = false;

    // Dependancies
    private Rigidbody rigidBody = null;

    /// <summary>
    /// Temporary solution to the movement optimization problem.
    /// </summary>
    [SerializeField] private Transform Up = null;
    [SerializeField] private Transform Down = null;
    [SerializeField] private Transform Left = null;
    [SerializeField] private Transform Right = null;
    [SerializeField]
    private Direction currentDirection = Direction.None;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        if (transform.CompareTag("Player") == true)
        {
            isEntityPlayer = true;
        }
    }

    private void Update()
    {
        // Consider abstracting the movement controller to seperate
        // entity responsibilities
        if (isEntityPlayer == true)
        {
            //Temporary solution to the movement optimization problem.
            if (Input.anyKey)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    if (Input.GetKey(KeyCode.A))
                    {
                        Move(Direction.UpLeft);
                    }
                    else
                    {
                        Move(Direction.Up);
                    }
                }
                if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
                {
                    Move(Direction.UpRight);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    Move(Direction.Down);
                }
                if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
                {
                    Move(Direction.DownLeft);
                }
                if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
                {
                    Move(Direction.DownRight);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    Move(Direction.Left);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    Move(Direction.Right);
                }
            }
        }
    }

    public void Move(Direction newDirection)
    {
        currentDirection = newDirection;

        switch (currentDirection)
        {
            case Direction.Up:
                transform.position = Vector3.MoveTowards(transform.position, Up.transform.position, speed / 1000);
                break;
            case Direction.UpRight:
                break;
            case Direction.UpLeft:
                break;
            case Direction.Down:
                transform.position = Vector3.MoveTowards(transform.position, Down.transform.position, speed / 1000);
                break;
            case Direction.DownRight:
                break;
            case Direction.DownLeft:
                break;
            case Direction.Left:
                transform.position = Vector3.MoveTowards(transform.position, Left.transform.position, speed / 1000);
                break;
            case Direction.Right:
                transform.position = Vector3.MoveTowards(transform.position, Right.transform.position, speed / 1000);
                break;
            default:
                throw new System.Exception(string.Format(
                    "The direction {0} attempted to turn to by gameObject \"{1}\" is not valid!",
                    currentDirection.ToString(),
                    gameObject.name
                    ));
        }
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