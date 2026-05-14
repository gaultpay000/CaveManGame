using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;

//JsonUtility only serializes fields that are public OR marked with [SerializeField]
//this is why I'm using [SerializeField]. Not needed with Binary, but obviously binary has issues
[System.Serializable]
public class GameData2
{
    [SerializeField] private List<GUIDObjectToken> _guidObjects = new List<GUIDObjectToken>();
    public List<GUIDObjectToken> GetGUIDObjects { get { return _guidObjects; } }

    public int[] weapons = new int[3];
    public int[] GET_WEAPONS {  get { return weapons; } }

    public GameData2()
    {
        foreach (KeyValuePair<string, Transform> token in GUIDRegistry.GetRegistry)
        {
            _guidObjects.Add(new GUIDObjectToken(token.Key, token.Value));
        }
        GUIDRegistry.GetWeapons(weapons);
    }

    public void LoadData()
    {
        Debug.Log("Loading Data");

        foreach (GUIDObjectToken token in _guidObjects)
        {
            token.LoadGUID();
        }
    }
}

[System.Serializable]
public class GUIDObjectToken
{
    [SerializeField] private string _guid;
    [SerializeField] private VectorToken _postion;
    [SerializeField] private VectorToken _rotation;

    public string GetGUID { get { return _guid; } }
    public Vector3 GetPosition { get { return _postion.GetVector; } }
    public Vector3 GetRotation { get { return _rotation.GetVector; } }

    public GUIDObjectToken(string guid, Transform t)
    {
        _guid = guid;
        _postion = new VectorToken(t.position);
        _rotation = new VectorToken(t.rotation.eulerAngles);
    }

    public void LoadGUID()
    {
        Transform obj = GUIDRegistry.GetTransformFromKey(_guid);
        obj.transform.position = _postion.GetVector;
        obj.transform.rotation = Quaternion.Euler(_rotation.GetVector);
    }
}

[System.Serializable]
public class VectorToken
{
    [SerializeField] private float _x;
    [SerializeField] private float _y;
    [SerializeField] private float _z;

    public Vector3 GetVector { get { return new Vector3(_x, _y, _z); } }

    public VectorToken(float x, float y, float z)
    {
        _x = x;
        _y = y;
        _z = z;
    }

    public VectorToken(Vector3 v)
    {
        _x = v.x;
        _y = v.y;
        _z = v.z;
    }
}