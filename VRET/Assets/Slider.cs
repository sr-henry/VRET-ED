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
        slider.onValueChanged.AddListener(delegate { Tas(); });
    }

    private void Tas()
    {
        CharacterCustomization.Instance.ChangeBlendShapeValue(sName, slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
