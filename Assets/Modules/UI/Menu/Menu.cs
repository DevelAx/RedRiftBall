using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Menu : MonoBehaviour
{
    private static HashSet<MonoBehaviour> _dependants = new HashSet<MonoBehaviour>();

    public void Show()
    {
        gameObject.SetActive(true);
        UpdateDependants(false);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        UpdateDependants(true);
    }

    public static void AddDependant(MonoBehaviour obj)
    {
        _dependants.Add(obj);
    }

    private void UpdateDependants(bool enable)
    {
        foreach (var mono in _dependants)
            mono.enabled = enable;
    }
}
