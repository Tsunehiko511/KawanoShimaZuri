using System.Collections;
using UnityEngine;
using System;

public abstract class LuaInterpreterHandlerBase : MonoBehaviour
{
    protected bool flag;
    public int? result = null;

    protected virtual void Awake()
    {
        flag = true;
    }

    public IEnumerator WaitCoroutine()
    {
        yield return new WaitUntil(() => flag);
    }

    public void Wait(float duration)
    {
        StartCoroutine(WaitCor(duration));
    }
    IEnumerator WaitCor(float duration)
    {
        flag = false;
        if (ParamSO.Instance.RuntimeSpeedMode)
        {
            duration = 0;
        }
        yield return new WaitForSeconds(duration);
        flag = true;
    }

    public void NormalSpeedPoint()
    {
        ParamSO.Instance.RuntimeSpeedMode = false;
    }
}