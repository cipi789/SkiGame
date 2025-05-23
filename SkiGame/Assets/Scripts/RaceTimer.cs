using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    [SerializeField] private LeaderBoard leaderboard;

    private float raceTime = 0;
    private bool raceRunning;


    private void Update()
    {
        if (raceRunning)
            raceTime += Time.deltaTime;
    }
    private void OnEnable()
    {
        GameEvents.RaceStart += StartRace;
        GameEvents.RaceEnd += EndRace;
        GameEvents.RacePenalty += RacePenalty;
    }
    private void RacePenalty()
    {
        raceTime += 2;
        Debug.Log("Player recieved penalty");
    }
    private void OnDisable()
    {
        GameEvents.RaceStart -= StartRace;
        GameEvents.RaceEnd -= EndRace;
        GameEvents.RacePenalty -= RacePenalty;

    }

    private void StartRace()
    {
        raceTime = 0;
        raceRunning = true;
        Debug.Log("Race started");
    }
    private void EndRace()
    {
        raceRunning = false;
        GameData.Instance.racesCompleted++;
        leaderboard.AddResults(raceTime);
        Debug.Log("Race ended! Time:" + raceTime);
        Debug.Log("Races completed: " + GameData.Instance.racesCompleted);  

    }
}

