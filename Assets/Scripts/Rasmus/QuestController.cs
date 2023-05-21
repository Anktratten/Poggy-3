using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestController : MonoBehaviour
{
    bool questActive;
    public string heldObjectName;
    public string neededObject;
    public GameObject pickedUpItem;
    public Vector3 respawnPosition;
    public GameObject[] froggyLevels;
    public GameObject[] items;
    public bool playingLevel = false;
    public Camera levelCamera;
    public Camera overworldCamera;
    private void Start()
    {
        
    }
    void Update()
    {
        if (playingLevel == true && transform.position.y > 10)
        {
            GameObject.Find("Level Camera").transform.position = new Vector3(GameObject.Find("Level Camera").transform.position.x, 20, -10);
        }
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
            if (heldObjectName == collision.gameObject.GetComponent<QuestGiver>().wantedItem)
            {
                GameObject.Find("HeldItem").GetComponent<SpriteRenderer>().sprite = null;
                pickedUpItem = null;
                GameObject.Find("Player").GetComponent<Level_controller>().GainXP(1);
                collision.gameObject.GetComponent<QuestGiver>().wantedItem = "";

                CompleteQuest();
            }
            else if (collision.gameObject.GetComponent<QuestGiver>().wantedItem != "")
            {
                GetQuest(collision.gameObject);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return) && collision.gameObject.tag == "Object") //Pick up item
        {
            pickedUpItem = collision.gameObject;
            heldObjectName = collision.gameObject.GetComponent<Object>().objectName;
            GameObject.Find("HeldItem").GetComponent<HeldItemSprite>().ChangeSprite((int)((ItemSprites.ItemSpritesEnum)Enum.Parse(typeof(ItemSprites.ItemSpritesEnum), heldObjectName)), false); //BRUH THE FUCK IS THIS
            GameObject.Find("Player").GetComponent<Level_controller>().GainXP(1);
            collision.gameObject.SetActive(false);
            questActive = false;
            playingLevel = false;
            transform.position = respawnPosition;
            gameObject.GetComponent<Basic_motor_function>().Goal = respawnPosition;
            gameObject.GetComponent<Basic_motor_function>().Goal_2 = respawnPosition;
            GameObject.Find("Canvas").GetComponent<Canvas>().worldCamera = overworldCamera;
            GameObject.Find("Level Camera").GetComponent<Camera>().enabled = false;
            GameObject.Find("Overworld Camera").GetComponent<Camera>().enabled = true;
            GameObject.Find("Canvas").GetComponent<Canvas>().worldCamera = overworldCamera;
            GameObject.Find("Level Camera").transform.position = new Vector3(GameObject.Find("Level Camera").transform.position.x, 0, -10);

        }
    }
    void RecieveQuest(GameObject collidedObject)
    {
        neededObject = collidedObject.GetComponent<QuestGiver>().wantedItem;
    }
    void CompleteQuest()
    {

        if (heldObjectName == "carrotCoin" || heldObjectName == "wallet" || heldObjectName == "declaration" || heldObjectName == "cat" || heldObjectName == "waterBottle")
        {
            Basic_motor_function.coins += 3;
        }
        else if (heldObjectName == "vase")
        {
            Basic_motor_function.coins += 10;
        }
        else if (heldObjectName == "bible")
        {
            Basic_motor_function.coins += 15;
        }
        else if (heldObjectName == "painting")
        {
            Basic_motor_function.coins += 20;
        }
        else if (heldObjectName == "flowers")
        {
            //You win
        }
        heldObjectName = "";
        //Play sound
    }
    public void GetQuest(GameObject collidingObject)
    {
        GameObject.Find("Level Camera").GetComponent<Camera>().enabled = true;
        GameObject.Find("Overworld Camera").GetComponent<Camera>().enabled = false;
        respawnPosition = transform.position;
        if (pickedUpItem != null)
        {
            pickedUpItem.SetActive(true);
        }
        RecieveQuest(collidingObject);
        GameObject.Find("Player").GetComponent<Level_controller>().GainXP(1);
        GameObject.Find("HeldItem").GetComponent<HeldItemSprite>().ChangeSprite((int)((ItemSprites.ItemSpritesEnum)Enum.Parse(typeof(ItemSprites.ItemSpritesEnum), neededObject)), true);

        questActive = true;

        StartLevel();
    }
    public void StartLevel()
    {
        playingLevel = true;

        if (neededObject == "carrotCoin")
        {
            froggyLevels[0].SetActive(true);
            items[0].SetActive(true);
        }
        else if (neededObject == "wallet")
        {
            froggyLevels[1].SetActive(true);
            items[1].SetActive(true);
        }
        else if (neededObject == "declaration")
        {
            froggyLevels[2].SetActive(true);
            items[2].SetActive(true);
        }
        else if (neededObject == "cat")
        {
            froggyLevels[3].SetActive(true);
            items[3].SetActive(true);
        }
        else if (neededObject == "waterBottle")
        {
            froggyLevels[4].SetActive(true);
            items[4].SetActive(true);
        }

        transform.position = new Vector3(-70, -9.5f, 0);
        gameObject.GetComponent<Basic_motor_function>().Goal = new Vector3(-70, -9.5f, 0);
        gameObject.GetComponent<Basic_motor_function>().Goal_2 = new Vector3(-70, -9.5f, 0);
        GameObject.Find("Canvas").GetComponent<Canvas>().worldCamera = levelCamera;
    }

}
