using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Level Content
    public LevelData LevelInfo;
    //public ClientData[] ClientsInLevel;
    //public ClientData KarenTest;

    // UI Content
    public TextMeshProUGUI MessageName;
    public TextMeshProUGUI MessageText;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI[] AnswerButtons;
    public GameObject Popup;
    public GameObject EventPopup;
    public GameObject RatingPopup;
    public TextMeshProUGUI RatingText;
    public TextMeshProUGUI EventText;
    public TextMeshProUGUI EventTimer;
    public TextMeshProUGUI EventXtraInfo;

    // Level Progression Content
    public int ClientCount = 0;
    public int EventCount = 0;
    public int Rating = 0;
    public StopWatch Stowatch;
    public Timer Timer;
    public MenuManager Menus;

    public bool Solved = false;

    // Save Content

    public void Solve()
    {
        Solved = true;
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Round(Stowatch.currentTime) == LevelInfo.Events[EventCount].Timing)
        {
            Timer.startMinutes = LevelInfo.Events[EventCount].Cooldown;
            Timer.StartTimer();
            UpdateEventData();
            EventPopup.SetActive(true);
        }

        if (Mathf.Round(Stowatch.currentTime) == LevelInfo.Clients[0].timings[ClientCount])
        {
            UpdateClientData();
            Popup.SetActive(true);
        }

        if (Stowatch.currentTime >= LevelInfo.Clients[0].DeliveryTime)
        {
            TimerText.text = "Done!";
            RatingText.text = Rating.ToString();
            RatingPopup.SetActive(true);
            Popup.SetActive(false);
            //Menus.EndGame();
        }

        else
            TimerText.text = Stowatch.time.ToString(@"mm\:ss"); ;
    }

    void UpdateClientData()
    {
        MessageName.text = LevelInfo.Clients[0].name;
        MessageText.text = LevelInfo.Clients[0].Messages[ClientCount].Message;
        AnswerButtons[0].text = LevelInfo.Clients[0].Messages[ClientCount].Answers[0];
        AnswerButtons[1].text = LevelInfo.Clients[0].Messages[ClientCount].Answers[1];
    }

    void UpdateEventData()
    {
        EventText.text = LevelInfo.Events[EventCount].EventName;
        //EventTimer.text = Timer.currentTime.ToString();
        EventTimer.text = "in " + LevelInfo.Events[EventCount].Cooldown + " seconds. " + "it will take " + LevelInfo.Events[EventCount].GracePeriod + " extra seconds";

        if (LevelInfo.Events[EventCount].InRoute)
            EventXtraInfo.text = "In your Route";
        else
            EventXtraInfo.text = "On the next Intersection";
    }

    public void ShowEvent(int num)
    {
        EventText.text = LevelInfo.Events[num].EventName;
        //EventTimer.text = Timer.currentTime.ToString();
        EventTimer.text = "in " + LevelInfo.Events[num].Cooldown + " seconds. " + "it will take " + LevelInfo.Events[num].GracePeriod + " extra seconds";

        if (LevelInfo.Events[num].InRoute)
            EventXtraInfo.text = "In your Route";
        else
            EventXtraInfo.text = "On the next Intersection";

        EventPopup.SetActive(true);
    }

    public void CountUp()
    {
        if(ClientCount <= LevelInfo.Clients[0].timings.Length - 2)
            ClientCount++;

    }

    public void EventCountUp()
    {
        if (EventCount <= LevelInfo.Events.Length - 2)
            EventCount++;

    }

    public void GoodAnswer()
    {
        Rating++;
        if (Rating > 5)
            Rating = 5;
    }

    public void BadAnswer()
    {
        Rating--;
        if (Rating < 0)
            Rating = 0;
    }
}
//map:
//steal good map
//from a to b the character moves at a specific speed (maybe make it changeable thru UI or sth)
//stop(by itself or by command)
//change routes when getting to intersections
//have a set "ideal time", based on your speed it'd take x mins but with Shit Happening u delay so customers "know" when to go karen
//1 popup from other client
 
//client:
//text interface (maybe a tab u can open or a notif)
//timing between texts ? or activate with events
//star system at the end (completed time + events successfully avoided + deliveries done + money profit)

//    events:
//location for more story important ones(ie: hospital moment that later on ends with police etc)
//have radius around player where they'd spawn (temporary stuff like explosion here but it's fixed the next day etc)
//timing(cooldown + grace period)
//limit per route (based on distance)
//-
//mr game master kidnapper

//    3 min delivery
//map (greyed out except for important area)
//message notifs from clients (popups u can open)
//one route that can change once (other customer popup)
//events(mandatory + the switch each route has one)
//points in the map:
//A - Start
//B - 1st uber end
//C - 2nd uber end