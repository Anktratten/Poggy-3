using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{


    public float PlayerX;
    public float PlayerY;

    public float CameraX;
    public float CameraY;


    void OnCollisionEnter2D(Collision2D collision)
    {
       collision.gameObject.transform.position = new Vector2(transform.position.x + PlayerX, transform.position.y + PlayerY);
        var screen = GameObject.Find("Main Camera");
        screen.transform.position = new Vector3(transform.position.x + CameraX, transform.position.y + CameraY, -10);

    }

    
}
