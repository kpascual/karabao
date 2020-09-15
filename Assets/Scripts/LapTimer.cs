using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LapTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timerText;
    private bool isLapStarted = false;
    private float startTime;
    private float currentLapTime;
    private List<float> currentLapSplits = new List<float>();
    private float lastLapTime;
    public List<float> lapTimeHistory = new List<float>();
    public List<List<float>> lapSplitHistory = new List<List<float>>();
    public GameObject startFinish;
    public GameObject[] checkpoints;
    private List<int> checkpointsLeft = new List<int>();
    void Start()
    {
    }

    void StartLap() 
    {
        startTime = Time.time;
        currentLapSplits = new List<float>();
        checkpointsLeft = checkpoints.Select(cp => cp.GetInstanceID()).ToList();
    }

    public void CheckpointReached(int checkpointInstanceID) 
    {
        if (checkpointsLeft.Contains(checkpointInstanceID))
        {
            float lapSplit = Time.time - startTime;
            currentLapSplits.Add(lapSplit);
            Debug.Log("lap split: " + lapSplit.ToString());
            Debug.Log(checkpointInstanceID);

            checkpointsLeft.RemoveAll(cp => cp == checkpointInstanceID);
            Debug.Log(string.Join(",", checkpointsLeft));
        }
    }
    public void StartFinishReached() 
    {
        if (!isLapStarted)
        {
            isLapStarted = true;
            StartLap();
        } else if (checkpointsLeft.Count == 0) {
            // Record last lap
            lastLapTime = Time.time - startTime;
            lapTimeHistory.Add(lastLapTime);
            lapSplitHistory.Add(currentLapSplits);

            // Start a new lap
            StartLap();

            // Ensure lap time history is being recorded properly
            string dlaptimes = string.Join(",", lapTimeHistory);
            Debug.Log(dlaptimes);

            Debug.Log(string.Join(",", checkpointsLeft));
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isLapStarted) {
            currentLapTime = Time.time - startTime;
            timerText.text = currentLapTime.ToString("f2"); 
        }
    }
}
