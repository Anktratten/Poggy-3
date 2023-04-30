using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool paused;
    GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("Pause Menu");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(paused);
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            paused = true;
            pauseMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            paused = false;
            pauseMenu.SetActive(false);
        }
    }
}
