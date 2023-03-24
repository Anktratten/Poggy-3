using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public int directionInt;
    public float movementSpeed;
    float movementSpeedDelta;
    enum movementDirection
    {
        left, right, up, down
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movementSpeedDelta = movementSpeed * Time.deltaTime;
        if (directionInt == (int)movementDirection.right)
        {
            transform.position = new Vector3(transform.position.x + movementSpeedDelta, transform.position.y, transform.position.z);
        }
        else if (directionInt == (int)movementDirection.left)
        {
            transform.position = new Vector3(transform.position.x - movementSpeedDelta, transform.position.y, transform.position.z);
        }
        else if (directionInt == (int)movementDirection.up)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + movementSpeedDelta, transform.position.z);
        }
        else if (directionInt == (int)movementDirection.down)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - movementSpeedDelta, transform.position.z);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
