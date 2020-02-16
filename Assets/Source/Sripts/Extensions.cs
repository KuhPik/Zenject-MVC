using UnityEngine;

public static class Extensions
{
    public static T FindOrGet<T>(this T @object) where T : MonoBehaviour
    {
        if (@object == null) return GameObject.FindObjectOfType<T>();
        else return @object;
    }
}

