using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ControlEvent : UnityEvent<bool>
{
}

public class CarControlToggle : MonoBehaviour
{

    public ControlEvent controlChanged;


    void ControlToggled() {
        Debug.Log("control toggled");
    }
}
