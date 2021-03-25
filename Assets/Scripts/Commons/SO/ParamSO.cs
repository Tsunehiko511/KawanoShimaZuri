using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ParamSO : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] bool speedMode = default;
    public bool RuntimeSpeedMode { get; set; }
    [SerializeField] float messageSpeed = default;
    float runtimeMessageSpeed;
    public float RuntimeMessageSpeed
    {
        get
        {
            if (RuntimeSpeedMode) return 0;
            return runtimeMessageSpeed;
        }
        set => runtimeMessageSpeed = value;
    }
    [SerializeField] float moveSpeed = default;
    float runtimeMoveSpeed;
    public float RuntimeMoveSpeed
    {
        get
        {
            if (RuntimeSpeedMode) return 0;
            return runtimeMoveSpeed;
        }
        set => runtimeMoveSpeed = value;
    }
    [SerializeField] float waitTime = default;
    float runtimeWaitTime;
    public float RuntimeWaitTime
    {
        get
        {
            if (RuntimeSpeedMode) return 0;
            return runtimeWaitTime;
        }
        set => runtimeWaitTime = value;
    }



    public void OnAfterDeserialize()
    {
        RuntimeSpeedMode = speedMode;
        RuntimeMessageSpeed = messageSpeed;
        RuntimeMoveSpeed = moveSpeed;
        RuntimeWaitTime = waitTime;
    }

    public void OnBeforeSerialize()
    {
    }

    static ParamSO instance;
    public static ParamSO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<ParamSO>("ScriptableObjects/ParamSO");
            }
            return instance;
        }
    }
}
