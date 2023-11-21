using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Waypoins : MonoBehaviour
{
    public TMP_InputField playerSpeedUpdate;
    public GameObject button;

    public GameManager Manager;

    [SerializeField] private Transform[] routeWaypoints;
    [SerializeField] private Transform[] externalWaypoints;
    [SerializeField] private int waypointIndex;
    [SerializeField] private int ExternalWaypointIndex;
    [SerializeField] private int LineIndex;
    public List<Transform> Path;

    //[SerializeField] public string playerSpeedUpdate;
    [SerializeField] public float playerSpeed;

    [SerializeField] public bool waiting;
    [SerializeField] public bool inroute = true;

    public MessageData[] Messages;

    public LineRenderer Line;

    Vector2 direction;

    public Transform NextWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = routeWaypoints[waypointIndex].transform.position;
        Line.SetPosition(0, transform.position);

        //Unity Input Field
        playerSpeedUpdate.text = playerSpeed.ToString();

        Path.Add(routeWaypoints[0]);
    }

    // Update is called once per frame
    void Update()
    {
        UIUpdate();

        if (!waiting)
        {
            direction = transform.position - NextWaypoint.transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            direction.Normalize();

            transform.position = Vector2.MoveTowards(transform.position, NextWaypoint.position, playerSpeed * Time.deltaTime);

            Line.SetPosition(LineIndex, transform.position);
            
        }     
    }

    public void ContinueRoute()
    {
        inroute = true;
        waypointIndex += 1;
        ExternalWaypointIndex += 1;
        NextWaypoint = routeWaypoints[waypointIndex];
        Path.Add(NextWaypoint);
        waiting = false;
    }


    public void ChangeRoute()
    {
        inroute = false;
        NextWaypoint = externalWaypoints[ExternalWaypointIndex];
        waypointIndex += 1;
        Path.Add(NextWaypoint);
        waiting = false;  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("End Route"))
        {
            Debug.Log("End");
            waypointIndex = 1;
            waiting = true;
        }

        if (other.gameObject.CompareTag("Waypoint"))
        {
            Debug.Log("Waypoint");
            Line.positionCount++;
            LineIndex++;
            waypointIndex += 1;
            NextWaypoint = routeWaypoints[waypointIndex];
            Path.Add(NextWaypoint);
            inroute = true;
            Manager.ShowEvent(other.GetComponent<WaypointEvent>().CurrentEvent);
        }

        if (other.gameObject.CompareTag("External Waypoints"))
        {
            Debug.Log("External Waypoint");
            Line.positionCount++;
            LineIndex++;
            ExternalWaypointIndex += 1;
            NextWaypoint = routeWaypoints[waypointIndex];
            Path.Add(NextWaypoint);
            inroute = false;
        }

        if (other.gameObject.CompareTag("Event"))
        {
            Line.positionCount++;
            LineIndex++;
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