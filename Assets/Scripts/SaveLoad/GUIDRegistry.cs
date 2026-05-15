using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class GUIDRegistry
{
    private static Dictionary<string, Transform> _registry = new Dictionary<string, Transform>();

    //get saved registry
    public static Dictionary<string, Transform> GetRegistry { get { return _registry; } }
    static int[] heldWeapons = new int[3];

    static int currentScene = new int();

    //register the objects key and value
    public static void Register(string key, Transform value)
    {
        if (_registry.ContainsKey(key) == false)
        {
            _registry.Add(key, value);
        }
        else
        {
            _registry[key] = value;
        }
    }

    public static void SetWeapons(int[] weapons)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            {
                heldWeapons[i] = weapons[i];
            }
        }
        //Debug.Log($"{heldWeapons[0]}, {heldWeapons[1]}, {heldWeapons[2]}");
    }

    public static void SetScene(int scene)
    {
        currentScene = scene;
    }

    //find transform that matches the key
    public static Transform GetTransformFromKey(string key)
    {
        if (_registry.ContainsKey(key))
        {
            return _registry[key];
        }

        return null;
    }

    public static int[] GetWeapons(int[] weapons)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i] = heldWeapons[i];
        }
        return weapons;
    }

    public static int GetScene(int getScene)
    {
        getScene = currentScene;
        return currentScene;
    }
}