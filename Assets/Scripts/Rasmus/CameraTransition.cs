using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    GameObject overworldCamera;
    bool moved = false;
    // Start is called before the first frame update
    void Start()
    {
        overworldCamera = GameObject.Find("Overworld Camera");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(overworldCamera.transform.position.y - transform.position.y + "Is the y difference");
        Debug.Log(overworldCamera.transform.position.x - transform.position.x + "Is the x difference");
        if (gameObject.GetComponent<QuestController>().playingLevel == false)
        {
            if (overworldCamera.transform.position.y - transform.position.y <= -6)
            {
                overworldCamera.transform.position = new Vector3(overworldCamera.transform.position.x, overworldCamera.transform.position.y + 11, -10);
                moved = true;
            }
            if (overworldCamera.transform.position.y - transform.position.y >= 6)
            {
                overworldCamera.transform.position = new Vector3(overworldCamera.transform.position.x, overworldCamera.transform.position.y - 11, -10);
                moved = true;
            }
            if (overworldCamera.transform.position.x - transform.position.x <= -6)
            {
                overworldCamera.transform.position = new Vector3(overworldCamera.transform.position.x + 11, overworldCamera.transform.position.y, -10);
                moved = true;
            }
            if (overworldCamera.transform.position.x - transform.position.x >= 6)
            {
                overworldCamera.transform.position = new Vector3(overworldCamera.transform.position.x - 11, overworldCamera.transform.position.y, -10);
                moved = true;
            }
        }
    }
}
