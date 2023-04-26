using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldItemSprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSprite(int spriteNumber)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = ItemSprites.itemSpritesArray[spriteNumber];
    }
}
