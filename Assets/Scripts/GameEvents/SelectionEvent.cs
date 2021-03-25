using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using MoonSharp.Interpreter;
using UnityEngine.UI;

[MoonSharpUserData]
public class SelectionEvent : LuaInterpreterHandlerBase
{
    [SerializeField] GameObject selectPanel = default;
    [SerializeField] Text selectTextPrefab = default;

    private void Start()
    {
        // Choose("はい", "やだよ");
    }

    public void Choose(params string[] selectionItems)
    {
        selectPanel.SetActive(true);
        foreach (Transform child in selectPanel.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i=0; i< selectionItems.Length; i++)
        {
            Text selectText = Instantiate(selectTextPrefab, selectPanel.transform);
            selectText.text = selectionItems[i];
            if (i==0)
            {
                selectText.GetComponent<Selectable>().Select();
            }
        }
        Vector2 windowSize = selectPanel.GetComponent<RectTransform>().sizeDelta;
        windowSize.y = 20 + 50 * selectionItems.Length;
        selectPanel.GetComponent<RectTransform>().sizeDelta = windowSize;
        StartCoroutine(ChooseInner(selectionItems));
        // 選択肢を生成
    }

    IEnumerator ChooseInner(params string[] selectionItems)
    {
        flag = false;
        // 選択するまで待機
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space)  || Input.GetKeyDown(KeyCode.Return) || ParamSO.Instance.RuntimeSpeedMode);
        result = selectionItems.ToList().IndexOf(EventSystem.current.currentSelectedGameObject.GetComponent<Text>().text);
        selectPanel.SetActive(false);
        flag = true;
    }
}
