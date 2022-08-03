using UnityEngine;

public static class Vector
{
    public static Vector3 SetX(this Vector3 vector, float x)
    {
        vector.x = x;
        return vector;
    }

    public static Vector3 SetY(this Vector3 vector, float y)
    {
        vector.y = y;
        return vector;
    }

    public static Vector3 SetZ(this Vector3 vector, float z)
    {
        vector.z = z;
        return vector;
    }

    public static Vector2 SetX(this Vector2 vector, float x)
    {
        vector.x = x;
        return vector;
    }

    public static Vector2 SetY(this Vector2 vector, float y)
    {
        vector.y = y;
        return vector;
    }

    public static Vector3 PlusX(this Vector3 vector, float x)
    {
        vector.x += x;
        return vector;
    }

    public static Vector3 PlusY(this Vector3 vector, float y)
    {
        vector.y += y;
        return vector;
    }

    public static Vector3 PlusZ(this Vector3 vector, float z)
    {
        vector.z += z;
        return vector;
    }

    public static Vector2 PlusX(this Vector2 vector, float x)
    {
        vector.x += x;
        return vector;
    }

    public static Vector2 PlusY(this Vector2 vector, float y)
    {
        vector.y += y;
        return vector;
    }
}
