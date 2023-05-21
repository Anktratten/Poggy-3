using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool paused;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("game is paused =" + paused);
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            UnPause();
        }
    }
    public void Pause()
    {
        paused = true;
        pauseMenu.SetActive(true);
    }
    public void UnPause()
    {
        paused = false;
        pauseMenu.SetActive(false);
    }
}
