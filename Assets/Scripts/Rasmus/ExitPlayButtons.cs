using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPlayButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        GameObject.Find("PauseController").GetComponent<PauseController>().UnPause();
    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
