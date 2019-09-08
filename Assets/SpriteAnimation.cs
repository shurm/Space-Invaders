using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    private int i = 0;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdateSprite()
    {
        Sprite s = sprites[i];
        spriteRenderer.sprite = s;
        i = (i + 1) % sprites.Length;
    }

}
