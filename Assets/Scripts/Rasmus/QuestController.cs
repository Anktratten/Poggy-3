using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestController : MonoBehaviour
{
    bool questActive;
    public string heldObject;
    string neededObject;
    public GameObject pickedUpItem;
    public Vector3 respawnPosition;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Basic_motor_function.coins++;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (PauseController.paused)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Return) && collision.gameObject.tag == "Human")
        {
            if (questActive == true && heldObject == neededObject)
            {
                GameObject.Find("Player").GetComponent<Level_controller>().GainXP(1);
                CompleteQuest();
            }
            else
            {
                PickUpItem(collision.gameObject);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return) && collision.gameObject.tag == "Object") //Pick up item
        {

            pickedUpItem = collision.gameObject;
            heldObject = collision.gameObject.GetComponent<Object>().objectName;
            GameObject.Find("HeldItem").GetComponent<HeldItemSprite>().ChangeSprite((int)((ItemSprites.ItemSpritesEnum)Enum.Parse(typeof(ItemSprites.ItemSpritesEnum), heldObject)), false); //BRUH THE FUCK IS THIS
            GameObject.Find("Player").GetComponent<Level_controller>().GainXP(1);
            collision.gameObject.SetActive(false);
            questActive = false;
        }
    }
    void RecieveQuest(GameObject collidedObject)
    {
        neededObject = collidedObject.GetComponent<QuestGiver>().wantedItem;
    }
    void CompleteQuest()
    {

        if (heldObject == "carrotCoin" || heldObject == "wallet" || heldObject == "declaration" || heldObject == "cat" || heldObject == "waterBottle")
        {
            Basic_motor_function.coins += 3;
        }
        else if (heldObject == "vase")
        {
            Basic_motor_function.coins += 10;
        }
        else if (heldObject == "bible")
        {
            Basic_motor_function.coins += 15;
        }
        else if (heldObject == "painting")
        {
            Basic_motor_function.coins += 20;
        }
        else if (heldObject == "flowers")
        {
            //You win
        }
        heldObject = null;
        //Play sound
    }
    public void PickUpItem(GameObject collidingObject)
    {
        respawnPosition = transform.position;
        pickedUpItem.SetActive(true);
        RecieveQuest(collidingObject);
        GameObject.Find("Player").GetComponent<Level_controller>().GainXP(1);
        GameObject.Find("HeldItem").GetComponent<HeldItemSprite>().ChangeSprite((int)((ItemSprites.ItemSpritesEnum)Enum.Parse(typeof(ItemSprites.ItemSpritesEnum), neededObject)), true);
        questActive = true;
    }
}