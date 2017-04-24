using System;

namespace PureShape {

[Serializable]
public class Count {
    public int minimum; 			//Minimum value for our Count class.
    public int maximum; 			//Maximum value for our Count class.

    //Assignment constructor.
    public Count (int min, int max) {
        minimum = min;
        maximum = max;
    }
}

[Serializable]
public class Range {
    public float minimum;
    public float maximum;

    //Assignment constructor.
    public Range (float min, float max) {
        minimum = min;
        maximum = max;
    }
}

public class Tuple<T,U>
{
    public T Item1 { get; private set; }
    public U Item2 { get; private set; }

    public Tuple(T item1, U item2)
    {
        Item1 = item1;
        Item2 = item2;
    }
}

public static class Tuple
{
    public static Tuple<T, U> Create<T, U>(T item1, U item2)
    {
        return new Tuple<T, U>(item1, item2);
    }
}

}
