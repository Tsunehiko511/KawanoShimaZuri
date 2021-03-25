using System.Collections;
using MoonSharp.Interpreter;
using UnityEngine;
using UnityEngine.UI;

[MoonSharpUserData]
class EventData : LuaInterpreterHandlerBase
{
    [SerializeField] Text message = default;
    public void LogMessage(string meg)
    {
        Debug.Log(meg);
    }

    public void ShowMessage(string meg)
    {
        StartCoroutine(ShowMessageCorou(meg));
    }
    public IEnumerator ShowMessageCorou(string meg)
    {
        flag = false;
        message.text = "";
        foreach (char w in meg)
        {
            yield return new WaitForSeconds(0.05f);
            message.text += w;
        }
        yield return new WaitForSeconds(0.5f);
        flag = true;
    }
}
