using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowProximity : MonoBehaviour
{
    public Toggle toggle;

    private bool isShowProxBtnPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle.isOn)
        {
            isShowProxBtnPressed = true;
        }
        else
        {
            isShowProxBtnPressed = false;
        }
    }

    public void IsShowProximityPressed(bool isButtonPressed)
    {
        isShowProxBtnPressed = isButtonPressed;
    }

    public bool GetIsShowProximityPressed()
    {
        return isShowProxBtnPressed;
    }
}
