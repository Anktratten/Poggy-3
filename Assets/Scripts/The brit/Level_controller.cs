using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_controller : MonoBehaviour
{
    public int currentLevel = 0;
    public int TotalXP;
    public int[] LevelupXP;
    public int[] LevelupReward;
    public int xpBarInt;
    bool maxLevel = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(TotalXP);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            GainXP(1);
        }
    }

    public void GainXP(int XP)
    {
        if (maxLevel == true)
        {
            return;
        }
        if (LevelupXP[currentLevel] <= TotalXP)
        {
            currentLevel++;
            if (currentLevel == 5)
            {
                maxLevel = true;
                GameObject.Find("Lv Number").GetComponent<SpriteRenderer>().sprite = ItemSprites.numberSprites[5];
                GameObject.Find("Experience Bar").GetComponent<SpriteRenderer>().sprite = ItemSprites.xpBars[4];
                return;
            }
            switch (LevelupReward[currentLevel])
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
        xpBarInt = (TotalXP - (5 * currentLevel)) -1;
        GameObject.Find("Experience Bar").GetComponent<SpriteRenderer>().sprite = ItemSprites.xpBars[xpBarInt];
        GameObject.Find("Lv Number").GetComponent<SpriteRenderer>().sprite = ItemSprites.numberSprites[currentLevel];
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
