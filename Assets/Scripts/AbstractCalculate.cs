//Written by Lance Graham
//Strategy pattern - there are many different calculations that can be performed against two vectors
using UnityEngine;

public abstract class AbstractCalculate
{
    public abstract bool Calculate(Vector3 locationOne, Vector3 locationTwo);
}
