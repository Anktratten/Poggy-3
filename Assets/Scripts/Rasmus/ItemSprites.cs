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
    enum itemSpritesEnum
    {
        carrotCoin,
        vase,
        wallet,
        declaration,
        painting,
        waterBottle,
        bible,
        cat,
        flowers,
    }
}

