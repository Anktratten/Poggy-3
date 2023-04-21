using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_motor_function_ArvidTest : MonoBehaviour
{
    public Vector3 Goal_2;
    public Vector3 Goal;
    public Vector2 SprintGoal;
    bool Sprinting;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Goal = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Goal, speed * Time.deltaTime);
        if (transform.position == Goal)
            Goal = Goal_2;

        if (Input.GetKeyDown(KeyCode.W))
            ActionDecider(1, 0);
        else if (Input.GetKeyDown(KeyCode.S))
            ActionDecider(-1, 0);
        else if (Input.GetKeyDown(KeyCode.A))
            ActionDecider(0, -1);
        else if (Input.GetKeyDown(KeyCode.D))
            ActionDecider(0, 1);
        if (Sprinting == true)
            ActionDecider((int)SprintGoal.y, (int)SprintGoal.x);
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprinting = true;
        }
        else
        {
            Sprinting = false;
            SprintGoal = new Vector2();
        }
    }
    void ActionDecider(int y, int x)
    {
        if (transform.position != Goal)
        {
            Goal_2 = Goal + new Vector3(x, y);
        }
        else
        {
            Goal += new Vector3(x, y);
            Goal_2 = Goal;
        }

        if (Sprinting == true)
            SprintGoal = new Vector2(x, y);

    }
}
