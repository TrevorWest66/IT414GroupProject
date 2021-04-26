// Written by Lance Graham
// 03/01/2021
// Strategy pattern - there are many different calculations that can be performed against two vectors
using UnityEngine;

public abstract class AbstractCalculate
{
    public abstract bool Calculate(Vector3 locationOne, Vector3 locationTwo);
}
