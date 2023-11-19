using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Waypoins : MonoBehaviour
{
    public TMP_InputField playerSpeedUpdate;
    public GameObject button;

    [SerializeField] private Transform[] routeWaypoints;
    [SerializeField] private Transform[] externalWaypoints;
    [SerializeField] private int waypointIndex;
    [SerializeField] private int ExternalWaypointIndex;

    //[SerializeField] public string playerSpeedUpdate;
    [SerializeField] public float playerSpeed;

    [SerializeField] public bool waiting;

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

        if(!waiting)
        {
            Move();
        }

        Vector2 direction = transform.position - routeWaypoints[waypointIndex].transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        direction.Normalize();
    }

    private void Move()
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

    public void ChangeRoute()
    {
        if (ExternalWaypointIndex <= externalWaypoints.Length - 1)
        {
            Debug.Log("Change route");
            transform.position = Vector2.MoveTowards(transform.position, externalWaypoints[ExternalWaypointIndex].transform.position, playerSpeed * Time.deltaTime);
            if (transform.position == externalWaypoints[ExternalWaypointIndex].transform.position)
            {
                Debug.Log("Update");
                ExternalWaypointIndex += 1;
                waiting = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("End Route"))
        {
            Debug.Log("End");
            waypointIndex = 1;
            waiting = true;
        }

        if (other.gameObject.CompareTag("Event"))
        {
            Debug.Log("Event");
            waiting = true;
            button.SetActive(true);
        }
    }

    //Unity Input field update
    public void UIUpdate()
    {
        playerSpeed = float.Parse(playerSpeedUpdate.text);
    }
}
