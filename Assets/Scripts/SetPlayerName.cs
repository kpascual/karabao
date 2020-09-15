using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetPlayerName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       TMP_Text textObj = gameObject.GetComponent<TMP_Text>(); 
       textObj.text = PlayerPrefs.GetString("carName", "YourCar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
