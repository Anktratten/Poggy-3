using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneshift : MonoBehaviour
{
    public string Name;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoadScene(Name);
    }
    public void LoadScene(string menuName)
    {
        SceneManager.LoadScene(menuName);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
