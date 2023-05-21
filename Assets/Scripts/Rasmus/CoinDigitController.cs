using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinDigitController : MonoBehaviour
{
    public GameObject coinDigit1;
    public GameObject coinDigit2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        coinDigit1 = GameObject.Find("CoinDigit1");
        coinDigit2 = GameObject.Find("CoinDigit2");
        if (Basic_motor_function.coins.ToString().Length == 1)
        {
            coinDigit2.GetComponent<SpriteRenderer>().sprite = ItemSprites.numberSprites[Basic_motor_function.coins];
        }
        else if (Basic_motor_function.coins.ToString().Length == 2)
        {
            coinDigit1.GetComponent<SpriteRenderer>().sprite = ItemSprites.numberSprites[Basic_motor_function.coins.ToString()[0] - '0'];
            coinDigit2.GetComponent<SpriteRenderer>().sprite = ItemSprites.numberSprites[Basic_motor_function.coins.ToString()[1] - '0'];
        }
    }
}
