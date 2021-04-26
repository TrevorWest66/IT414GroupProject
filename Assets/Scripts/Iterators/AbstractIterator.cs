// Written by Lance Graham
// 03/23/2021
// Iterator Pattern - All concrete iterators must implement the two methods below
using System;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractIterator
{
    public abstract bool hasNext();
    public abstract Object next();
}
