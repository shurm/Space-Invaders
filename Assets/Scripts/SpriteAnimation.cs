using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    private int i = 0;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = sprites[0];
        i = 1;
    }

    public void UpdateSprite()
    {
        Sprite s = sprites[i];
        spriteRenderer.sprite = s;
        i = (i + 1) % sprites.Length;
    }

}
