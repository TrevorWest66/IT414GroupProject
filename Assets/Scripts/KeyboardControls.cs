// Written by Ellie McDonald
// 03/19/21
// This class holds information about the players control preferences
using System;
using UnityEngine;
public class KeyboardControls : MonoBehaviour
{
    private static KeyboardControls instance = null;
    private KeyboardControlsEnum controlType = KeyboardControlsEnum.Arrows; // default is arrows, when game starts
    private DateTime timeControlsChanged = DateTime.Now;

    public static GameObject controlsSingleton;


    private void Awake()
    {
        controlsSingleton = GameObject.FindGameObjectWithTag("OptionMenu").transform.parent.gameObject;
        // if instance is not yet set, set it and make it persistent between scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(controlsSingleton);
        }
        else
        {
            // if instance is already set and this is not the same object, destroy it
            if (this != instance) { Destroy(gameObject); }
        }
    }
    public static KeyboardControls Instance
    {
        get 
        {
            return KeyboardControls.instance; 
        }
    }


    public KeyboardControlsEnum ControlType
    {
        get { return controlType; }
        set 
        { 
            controlType = value; 
            timeControlsChanged = DateTime.Now;
        }
    }

    public DateTime TimeControlsChanged
    {
        get { return this.timeControlsChanged; }
    }

    /**
     * Use for the options menu to set prefernces when the toggle button is clicked
     */
    public void OnClickLeft()
    {
        if (controlType.Equals(KeyboardControlsEnum.Arrows))
        {
            controlType = KeyboardControlsEnum.WASD;
            timeControlsChanged = DateTime.Now;
        }

        else if (controlType.Equals(KeyboardControlsEnum.WASD))
        {
            controlType = KeyboardControlsEnum.Arrows;
            timeControlsChanged = DateTime.Now;
        }

        // This flips the toggle to make is appear like the preferences have been changed
        transform.Rotate(Vector3.forward * 180); 
    }

}
