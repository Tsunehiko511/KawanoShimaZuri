using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FlagSO : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] List<Flag> initFlags = new List<Flag>();

    [NonSerialized]
    public List<Flag> flags = new List<Flag>();

    public void OnAfterDeserialize()
    {
        flags.Clear();
        for (int i = 0; i < initFlags.Count; i++)
        {
            flags.Add(new Flag(initFlags[i]));
        }
        Debug.Log("aaa");
    }

    public void OnBeforeSerialize()
    {
    }
}

[Serializable]
public class Flag
{
    public string name;
    public bool value;
    public Flag(Flag flagObj)
    {
        this.name = flagObj.name;
        this.value = flagObj.value;
    }
}