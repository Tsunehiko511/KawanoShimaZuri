using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

[MoonSharpUserData]
public class FlagManager : LuaInterpreterHandlerBase
{
    [SerializeField] List<Flag> flags = new List<Flag>();

    public bool GetFlag(string flagName)
    {
        Flag flag = flags.Find(x => x.name == flagName);
        return flag.value;
    }

    public void SetFlag(string flagName, bool value)
    {
        Flag flag = flags.Find(x => x.name == flagName);
        flag.value = value;
    }
}
