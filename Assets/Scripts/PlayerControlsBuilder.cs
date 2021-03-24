// Written by Ellie McDonald
// 3/13/21
// These classes use the builder pattern to help set the controls for the player
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerControlsBuilder
{
    public abstract List<KeyCode> SetPlayerControls();
}

// Inherits from builder to have unique method executions
public class ArrowControlsBuilder : PlayerControlsBuilder
{
    private List<KeyCode> listOfKeys = new List<KeyCode>();
    private KeyCode left, right, forward, backward, jump;
    private XmlParser anXmlParser = new XmlParser();
    public override List<KeyCode> SetPlayerControls()
    {
        anXmlParser.loadDocument("ArrowControls.xml");
        forward = anXmlParser.parseXml("forward");      // Up arrow
        backward = anXmlParser.parseXml("backward");    // Down arow
        left = anXmlParser.parseXml("left");            // Left arrow
        right = anXmlParser.parseXml("right");          // Right arrow
        jump = anXmlParser.parseXml("jump");            // Space bar

        listOfKeys.Add(forward);
        listOfKeys.Add(backward);
        listOfKeys.Add(left);
        listOfKeys.Add(right);
        listOfKeys.Add(jump);

        //Debug.Log("Set Contols for arrows.");
        return listOfKeys;
    }

}

// Inherits from builder to have unique method executions
public class WASDContolsBuilder : PlayerControlsBuilder
{

    private List<KeyCode> listOfKeys = new List<KeyCode>();
    private KeyCode left, right, forward, backward, jump;
    private XmlParser anXmlParser = new XmlParser();
    public override List<KeyCode> SetPlayerControls()
    {
        anXmlParser.loadDocument("WASDControls.xml");
        forward = anXmlParser.parseXml("forward");      // W 
        backward = anXmlParser.parseXml("backward");    //S 
        left = anXmlParser.parseXml("left");            //A
        right = anXmlParser.parseXml("right");          //D 
        jump = anXmlParser.parseXml("jump");            // Space bar

        listOfKeys.Add(forward);
        listOfKeys.Add(backward);
        listOfKeys.Add(left);
        listOfKeys.Add(right);
        listOfKeys.Add(jump);

        //Debug.Log("Set Contols for wasd.");
        return listOfKeys;
    }

}

// Builder Director constructs the builder to execute the unique builder class public class BuilderDirector
public class BuilderDirector
{
    public void Construct(PlayerControlsBuilder aBuilder)
    {
        aBuilder.SetPlayerControls();
    }
}
