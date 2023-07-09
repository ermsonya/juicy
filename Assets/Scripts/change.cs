using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class change : MonoBehaviour
{
  
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite; 
    public Sprite usualSprite;

    // Update is called once per frame
    void Update()
    {
        if (CutAppear.change)
        {
            spriteRenderer.sprite = newSprite;
        }
        else
            spriteRenderer.sprite = usualSprite;
    }
}
