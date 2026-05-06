using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteAlways]
public class GUIDObject : MonoBehaviour
{
    [SerializeField] private string _GUID;

    private void OnEnable()
    {
        if (_GUID == string.Empty)
        {
            GenerateGUID();
        }
    }

    private void Start()
    {
        if (_GUID == string.Empty)
        {
            GenerateGUID();
        }

        if (Application.isPlaying == false)
        {
            return;
        }

        GUIDRegistry.Register(_GUID, transform);
    }

    //make identifier string
    [ContextMenu("Generate GUID")] //for editor
    public void GenerateGUID()
    {
        _GUID = System.Guid.NewGuid().ToString();
    }
}

