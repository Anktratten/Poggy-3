using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSprites : MonoBehaviour
{
    public Sprite[] itemsSpritesArrayPublic = new Sprite[9];
    public static Sprite[] itemSpritesArray = new Sprite[9];
    private void Start()
    {
        itemSpritesArray = itemsSpritesArrayPublic;
    }
    public enum itemSpritesEnum
    {
        carrotCoin = 0,
        wallet = 1,
        declaration = 2,
        cat = 3,
        waterBottle = 4,

        vase = 5, //5
        bible = 6, //10
        painting = 7, //15

        flowers = 8, //40
    }
}

