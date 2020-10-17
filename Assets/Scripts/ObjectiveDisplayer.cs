using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveDisplayer : MonoBehaviour
{
    public Text objectiveText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ListenLapMessages(string message) {
        objectiveText.text = message;
    }
}
