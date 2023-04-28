using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{


    public float PlayerX;
    public float PlayerY;
    public float PlayerZ;

    public float CameraX;
    public float CameraY;
    public float CameraZ = -10;


    void OnCollisionEnter2D(Collision2D collision)
    {

        var frog = GameObject.Find("Player");
        frog.transform.position = new Vector3(transform.position.x + PlayerX, transform.position.y + PlayerY, transform.position.z + PlayerZ);
        var screen = GameObject.Find("Main Camera");
        screen.transform.position = new Vector3(transform.position.x + CameraX, transform.position.y + CameraY, transform.position.z + CameraZ);

    }

    
}
