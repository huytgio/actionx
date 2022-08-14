using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingPanel;
    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void OpenSetting()
    {
        SettingPanel.SetActive(true);
    }

    public void CloseSetting()
    {
        SettingPanel.SetActive(false);
    }

    public void ExitGame(){
        Debug.Log("Exitting");
        Application.Quit();
    }
}
