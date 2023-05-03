using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FroggyChildCollider : MonoBehaviour
{
    public bool touchingLog = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Log")
        {
            touchingLog = true;
        }
        else
        {
            touchingLog = false;
        }
    }
}
