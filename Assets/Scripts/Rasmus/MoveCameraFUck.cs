using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraFUck : MonoBehaviour
{
    float targetposition;
    // Start is called before the first frame update
    void Start()
    {
        targetposition = -2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > targetposition)
        {
            targetposition = targetposition + 20;
            GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        }
    }
}
