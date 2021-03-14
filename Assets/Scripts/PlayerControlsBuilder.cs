using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class PlayerControlsBuilder
{
    public abstract string SetPlayerControls();
}

// Inherits from builder to have unique method executions
public class ArrowControlsBuilder : PlayerControlsBuilder
{
    public override string SetPlayerControls()
    {
        return "ArrowControls.xml";
    }

}

// Inherits from builder to have unique method executions
public class WASDContolsBuilder : PlayerControlsBuilder
{
    public override string SetPlayerControls()
    {
        return "WASDControls.xml";
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
