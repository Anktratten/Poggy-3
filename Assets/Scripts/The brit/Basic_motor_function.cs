using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Basic_motor_function : MonoBehaviour
{
    public static int coins;
    public static int questsCompleted;
    public static int xp;

    public LayerMask Collision;
    public LayerMask Logs;
    bool logged;
    public Vector3 Goal_2;
    public Vector3 Goal;
    public Vector2 SprintGoal;
    bool Sprinting;
    [HideInInspector]
    public bool LeapEnabled = false;
    public double speed;
    Animator anim;
    public double constant;
    int secondDir;
    public AudioClip Jump;
    public AudioClip DeathSound;

    public bool respawning;

    public int lives;

    public float timeOnWater;
    // Start is called before the first frame update
    void Start()
    {
        lives = 4;
        SprintGoal = new Vector2(1, 0);
        Goal = transform.position;
        Goal_2 = Goal;
        anim = GetComponent<Animator>();
        anim.SetFloat("Speed", (float)(speed * constant));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerPrefs.SetInt("level", 0);
        }
        if (PauseController.paused == true)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoseLife();
        }
        Debug.Log(logged);
        if (logged != true)
        transform.position = Vector2.MoveTowards(transform.position, Goal, (float)speed * Time.deltaTime);

        if (transform.position == Goal)
        {
            if (Physics2D.OverlapBox(transform.position - new Vector3(0, 0.5f, 0), transform.localScale * 1f, 1, Logs))
            {
                transform.parent = Physics2D.OverlapBox(transform.position - new Vector3(0, 0.5f, 0), transform.localScale * 1f, 1, Logs).transform;
                logged = true;
            }
            else
            {
                transform.parent = null;
                logged = false;
            }
            anim.SetBool("Jump", false);
            anim.SetTrigger("StopJump");
            if(Goal != Goal_2)
            {
                anim.SetBool("Jump", true);
                anim.SetInteger("Direction", secondDir);
                AudioSource.PlayClipAtPoint(Jump, transform.position);
            }
            Goal = Goal_2;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
            ActionDecider(1, 0, 1);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            ActionDecider(-1, 0, 0);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            ActionDecider(0, -1, -1);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            ActionDecider(0, 1, -1);
        if (Sprinting == true)
            ActionDecider((int)SprintGoal.y, (int)SprintGoal.x, 2);
        
        if (Input.GetKey(KeyCode.LeftShift) && logged == false)
        {
            Sprinting = true;
        }
        else
        {
            Sprinting = false;
            SprintGoal = new Vector2(1, 0);
        }
    }
    void ActionDecider(int y, int x, int dir)
    {
        if (Physics2D.OverlapBox(Goal + new Vector3(x, y), transform.localScale * 0.1f, 1, Collision))
            return;

        if (logged)
        {
            transform.parent = null;
            logged = false;
            Goal = transform.position;
        }
        if (x != 0)
            transform.localScale = new Vector3(x, 1, 1);

        anim.SetInteger("Direction", dir);
        anim.SetBool("Jump", true);

        if (transform.position != Goal)
        {
            Goal_2 = Goal + new Vector3(x, y);
            secondDir = dir;
        }
        else if (LeapEnabled == true && Input.GetKey(KeyCode.Z))
        {
            AudioSource.PlayClipAtPoint(Jump, transform.position);
            Goal = transform.position + new Vector3(x * 2, y * 2);
            Goal_2 = Goal;
        }
        else
        {
            AudioSource.PlayClipAtPoint(Jump, transform.position);
            Goal = transform.position + new Vector3(x, y);
            Goal = new Vector3(Mathf.Round(Goal.x), Mathf.Round(Goal.y));
            Goal_2 = Goal;
        }

        if (Sprinting == true)
            SprintGoal = new Vector2(x, y);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (PauseController.paused == true || respawning == true)
        {
            return;
        }
        if (collision.gameObject.tag == "Car")
        {
            LoseLife();
        }
        if (collision.gameObject.tag == "Water" && Goal == transform.position)
        {
            if (logged == false)
                Death();
        }
    }
    void LoseLife()
    {
        AudioSource.PlayClipAtPoint(DeathSound, transform.position);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        respawning = true;
        Invoke("DisableRespawning", 3);
        lives--;
        GameObject.Find("Heart " + (lives + 1).ToString()).GetComponent<SpriteRenderer>().sprite = ItemSprites.disabledHeart;
        if (lives < 0)
        {
            Death();
        }
    }
    void Death()
    {
        Debug.Log("death");
        //GameObject.Find("Froggy").GetComponent<QuestController>().heldObject = "";
        //GameObject.Find("HeldItem").GetComponent<SpriteRenderer>().sprite = null;
        //GameObject.Find("Player").GetComponent<QuestController>().pickedUpItem.SetActive(true);
        //Display death
        //if (gameObject.GetComponent<QuestController>().respawnPosition == null)

        //}
        //else
        //{

          transform.position = gameObject.GetComponent<QuestController>().respawnPosition;
        Goal = transform.position;
        Goal_2 = Goal;
        GameObject.Find("Canvas").GetComponent<Canvas>().worldCamera = gameObject.GetComponent<QuestController>().overworldCamera;
        GameObject.Find("Level Camera").GetComponent<Camera>().enabled = false;
        GameObject.Find("Overworld Camera").GetComponent<Camera>().enabled = true;
        //Goal = gameObject.GetComponent<QuestController>().respawnPosition;
        //}
        lives = 4;
    }
    void DisableRespawning()
    {
        respawning = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
}
