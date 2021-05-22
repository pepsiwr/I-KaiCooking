using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CTRL_Scene : MonoBehaviour
{
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
        
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
