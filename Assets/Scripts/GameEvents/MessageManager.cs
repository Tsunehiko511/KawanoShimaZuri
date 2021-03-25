using System.Collections;
using MoonSharp.Interpreter;
using UnityEngine;
using UnityEngine.UI;

[MoonSharpUserData]
public class MessageManager : LuaInterpreterHandlerBase
{
    [SerializeField] Text messageText = default;
    [SerializeField] SoundManager sound = default;

    public void ShowMessage(string message)
    {
        StartCoroutine(ShowMessageCor(message));
    }
    IEnumerator ShowMessageCor(string message)
    {
        flag = false;
        messageText.text = "";
        int count = 0;
        foreach (char c in message)
        {
            yield return new WaitForSeconds(ParamSO.Instance.RuntimeMessageSpeed);
            messageText.text += c;
            count++;
            if (count%2==1)
            {
                sound.PlaySE(SoundManager.SE.Message);
            }
        }
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Space) || ParamSO.Instance.RuntimeSpeedMode);
        // 選択によって結果を変えられる
        if (Input.GetKeyDown(KeyCode.A))
        {
            result = 11;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            result = 22;
        }
        flag = true;
    }
    public void ClearMessage()
    {
        messageText.text = "";
    }
}
