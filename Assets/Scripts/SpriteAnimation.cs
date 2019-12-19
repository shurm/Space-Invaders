using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    private int i = 0;

    private SpriteRenderer spriteRenderer, spriteRendererBottomView;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRendererBottomView = transform.GetChild(0).GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
        i = 1;
    }
    /*
    public void Update()
    {
        UpdateSprite();
    }
    */
    public void UpdateSprite()
    {
        Sprite s = sprites[i];
        spriteRenderer.sprite = s;
       // spriteRendererBottomView.sprite = s;
        i = (i + 1) % sprites.Length;
    }

}
