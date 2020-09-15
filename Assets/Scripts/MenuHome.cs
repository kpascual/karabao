using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LoadMultiplayer()
    {
        SceneManager.LoadScene("MultiplayerTrack");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
