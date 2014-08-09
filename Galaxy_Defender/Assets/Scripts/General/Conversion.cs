using UnityEngine;
using System.Collections;

public class Conversion
{
    //-- converts mouse coordinates from bottom left origin to top left origin
    public static Vector2 ConvertMouseCoordinates(Vector2 point)
    {
        Vector2 result = Vector2.zero;

        result.x = point.x;
        result.y = Screen.height - point.y;

        return result;
    }
}
