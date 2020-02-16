using UnityEngine;

public static class Extensions
{
    public static T FindOrGet<T>(this T @object) where T : MonoBehaviour
    {
        if (@object == null)
        {
            @object = GameObject.FindObjectOfType<T>();
            return @object;
        }

        else return @object;
    }
}

