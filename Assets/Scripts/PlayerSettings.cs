using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    public Text textCarName;
    public Text currentCarName;
    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log(PlayerPrefs.GetString("carName"));
        currentCarName.text = PlayerPrefs.GetString("carName");
    }

    // Update is called once per frame
    public void SetCarName()
    {
        PlayerPrefs.SetString("carName", textCarName.text);
    }
}
