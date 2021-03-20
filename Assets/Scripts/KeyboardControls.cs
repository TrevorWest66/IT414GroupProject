using System;
public class KeyboardControls
{
    private bool controlIsArrows = true; // default is arrows, when game starts
    public bool ControlIsArrows
    {
        get { return this.controlIsArrows; }
        set { this.controlIsArrows = value; }
    }
}
