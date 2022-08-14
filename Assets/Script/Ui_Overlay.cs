using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_Overlay : MonoBehaviour
{
    public static Ui_Overlay UI;

    private void Awake()
    {
        if (UI != null)
        {
            Destroy(UI);
        }
        else { UI = this; }
        DontDestroyOnLoad(this);
    }
}
