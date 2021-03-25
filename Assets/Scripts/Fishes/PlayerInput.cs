using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public bool OnSpace { get; private set;}
    void Update()
    {
        OnSpace = Input.GetKey(KeyCode.Space);
    }
}
