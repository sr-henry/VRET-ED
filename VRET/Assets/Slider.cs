using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public string sName;
    private UnityEngine.UI.Slider slider;


    void Start()
    {
        slider = GetComponent<UnityEngine.UI.Slider>();
        slider.onValueChanged.AddListener(delegate { Task(); });
    }

    private void Task()
    {
        CharacterCustomization.Instance.ChangeBlendShapeValue(sName, slider.value);
    }

}
