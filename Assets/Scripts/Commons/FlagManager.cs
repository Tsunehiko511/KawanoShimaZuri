using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

[MoonSharpUserData]
public class FlagManager : LuaInterpreterHandlerBase
{
    [SerializeField] FlagSO flagSO = default;
    // [SerializeField] List<Flag> flags = new List<Flag>();

    public bool GetFlag(string flagName)
    {
        return flagSO.GetFlag(flagName);
    }

    public void SetFlag(string flagName, bool value)
    {
        flagSO.SetFlag(flagName, value);
    }
}
