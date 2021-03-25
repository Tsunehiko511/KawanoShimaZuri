using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugUI : MonoBehaviour
{
    [SerializeField] bool debugMode = default;
    [SerializeField] FishMove fish = default;
    [SerializeField] Slider escapeSlider = default;
    [SerializeField] Slider fishDistanceSlider = default;

    private void Start()
    {
        escapeSlider.maxValue = FishMove.ESCAPE_BORDER;
        escapeSlider.minValue = 0;
        fishDistanceSlider.maxValue = FishMove.ESCAPE_DISTANCE;
        fishDistanceSlider.minValue = 0;
    }

    private void Update()
    {
        if (debugMode)
        {
            ShowPanel();
        }
        else
        {
            HidePanel();
        }
    }

    void ShowPanel()
    {
        escapeSlider.value = fish.escapeValue;
        fishDistanceSlider.value = fish.MovingDistance;

    }


    void HidePanel()
    {
        escapeSlider.gameObject.SetActive(false);
        fishDistanceSlider.gameObject.SetActive(false);
    }

}
