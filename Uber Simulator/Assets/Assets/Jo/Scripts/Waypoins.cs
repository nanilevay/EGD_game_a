using TMPro;
using UnityEngine;

public class Waypoins : MonoBehaviour
{
    public TMP_InputField playerSpeedUpdate;

    [SerializeField] private Transform[] routeWaypoints;
    [SerializeField] private Transform[] externalWaypoints;
    [SerializeField] private int waypointIndex;

    //[SerializeField] public string playerSpeedUpdate;
    [SerializeField] public float playerSpeed;

    [SerializeField] private bool waiting;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = routeWaypoints[waypointIndex].transform.position;

        //Unity Input Field
        playerSpeedUpdate.text = playerSpeed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UIUpdate();
        Move();

        Vector2 direction = transform.position - routeWaypoints[waypointIndex].transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        direction.Normalize();
    }

    private void Move()
    {
        if (!waiting)
        {
            if (waypointIndex <= routeWaypoints.Length - 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, routeWaypoints[waypointIndex].transform.position, playerSpeed * Time.deltaTime);
                if (transform.position == routeWaypoints[waypointIndex].transform.position)
                {
                    waypointIndex += 1;
                }
            }
        }

        else
        {
            //Change waypoint path
        }

    }

    //Unity Input field update
    public void UIUpdate()
    {
        playerSpeed = float.Parse(playerSpeedUpdate.text);
    }
}
