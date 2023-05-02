using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y <=39 )
        {
         transform.position = new Vector2(0, transform.position.y + 1 * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
