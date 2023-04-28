using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_controller : MonoBehaviour
{
    public int CurrentLevel = 0;
    public int TotalXP;
    public int[] LevelupXP;
    public int[] LevelupReward;
    public int xpBarInt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            GainXP(1);
    }

    public void GainXP(int XP)
    {
        if (LevelupXP[CurrentLevel] <= TotalXP)
        {
            CurrentLevel++;
            switch (LevelupReward[CurrentLevel])
            {
                case 1:
                    MotorFunctionUpgrade(1);
                    break;
                case 2:
                    MotorFunctionUpgrade(2);
                    break;
            }
        }
        TotalXP++;
        xpBarInt = (TotalXP - (5 * CurrentLevel)) -1;
        GameObject.Find("Experience Bar").GetComponent<SpriteRenderer>().sprite = ItemSprites.xpBars[xpBarInt];
    }
    void MotorFunctionUpgrade(int Reward)
    {
        var upgrade = gameObject.GetComponent<Basic_motor_function>();
        switch (Reward)
        {
            case 1:
                upgrade.speed *= 1.20;
                upgrade.GetComponent<Animator>().SetFloat("Speed", (float)(upgrade.speed * upgrade.constant));
                break;
            case 2:
                upgrade.LeapEnabled = true;
                break;
        }
    }
}
