using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    GameObject cursorObj;
    void Awake()
    {
        cursorObj = transform.GetChild(0).gameObject;
        cursorObj.SetActive(false);
    }

    public void OnSelect(BaseEventData eventData)
    {
        cursorObj.SetActive(true);
    }
    public void OnDeselect(BaseEventData eventData)
    {
        cursorObj.SetActive(false);
    }
}
