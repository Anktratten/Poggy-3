using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterKeyTrigger : MonoBehaviour
{
    bool questActive;
    string heldObject;
    string neededObject;

    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Return) && collision.gameObject.tag == "Human")
        {
            if (questActive == false)
            {
                RecieveQuest(collision.gameObject);
            }
            else if (questActive == true && heldObject == neededObject)
            {
                CompleteQuest();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return) && collision.gameObject.tag == "Object")
        {
            heldObject = collision.gameObject.GetComponent<Object>().objectName;
            Destroy(collision.gameObject);
        }
    }
    void RecieveQuest(GameObject collidedObject)
    {
        neededObject = collidedObject.GetComponent<QuestGiver>().wantedItem;
    }
    void CompleteQuest()
    {
        heldObject = null;
    }
}
