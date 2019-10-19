using UnityEngine;

public static class MonoBehaviourExtensions
{
    private const string _noInstanceFound = "No instance of the '{0}' type is found!";
    private const string _noInstancesFound = "No instances of the '{0}' type are found!";

    public static T RequireComponent<T>(this MonoBehaviour mono) where T : class
    {
        T component = mono.GetComponent<T>();
        Debug.AssertFormat(component != null, _noInstanceFound, typeof(T));
        return component;
    }

    public static T RequireComponentInChildren<T>(this MonoBehaviour mono) where T : UnityEngine.Object
    {
        T component = mono.GetComponentInChildren<T>();
        Debug.AssertFormat(component != null, _noInstanceFound, typeof(T));
        return component;
    }

    public static T RequireComponentInParent<T>(this MonoBehaviour mono) where T : class
    {
        T component = mono.GetComponentInParent<T>();
        Debug.AssertFormat(component != null, _noInstanceFound, typeof(T));
        return component;
    }

    public static T[] RequireComponents<T>(this MonoBehaviour mono) where T : UnityEngine.Object
    {
        T[] components = mono.GetComponents<T>();
        Debug.AssertFormat(components.Length > 0, _noInstancesFound, typeof(T));
        return components;
    }

    public static T[] RequireComponentsInChildren<T>(this MonoBehaviour mono) where T : UnityEngine.Object
    {
        T[] components = mono.GetComponentsInChildren<T>();
        Debug.AssertFormat(components.Length > 0, _noInstancesFound, typeof(T));
        return components;
    }

    public static void Assert(this MonoBehaviour mono, UnityEngine.Object obj)
    {
        Debug.Assert(obj, $"Object shouldn't be null at '{mono.name}'!");
    }
}
