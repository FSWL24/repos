using System.Collections.Generic;

public class ObjectArrayEqualityComparer : IEqualityComparer<object[]>
{
    public bool Equals(object[] x, object[] y)
    {
        if (x == null || y == null)
            return x == y;

        if (x.Length != y.Length)
            return false;

        for (int i = 0; i < x.Length; i++)
        {
            if (!Equals(x[i], y[i]))
                return false;
        }

        return true;
    }

    public int GetHashCode(object[] obj)
    {
        if (obj == null)
            return 0;

        int hash = 17;
        foreach (var item in obj)
        {
            hash = hash * 31 + (item?.GetHashCode() ?? 0);
        }

        return hash;
    }
}
