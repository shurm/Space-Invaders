using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    public Sprite[] activeSprites;
    public GameObject[] gameObjectSpriteFrames;

    public Sprite[] deadSprites;
    private int i = 0;

    private SpriteRenderer spriteRenderer, spriteRendererBottomView;

    private MeshRenderer[] renderers;

    void Start()
    {
        foreach (GameObject gameObjectSpriteFrame in gameObjectSpriteFrames)
            gameObjectSpriteFrame.SetActive(true);

        renderers = GetComponentsInChildren<MeshRenderer>();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        UpdateSprite();
    }

    public void ReplaceWithDeadSprite()
    {
        i = (i + 1) % activeSprites.Length;

        Sprite s = deadSprites[i];
        spriteRenderer.sprite = s;
    }

    private void DisplayOnlyCorrectGameObjects()
    {
        for (int a = 0; a < i; a++)
            gameObjectSpriteFrames[a].SetActive(false);

        gameObjectSpriteFrames[i].SetActive(true);

        for (int a = i + 1; a < gameObjectSpriteFrames.Length; a++)
            gameObjectSpriteFrames[a].SetActive(false);
    }

    public void UpdateSprite()
    {
        Sprite s = activeSprites[i];
        spriteRenderer.sprite = s;

        DisplayOnlyCorrectGameObjects();

        i = (i + 1) % activeSprites.Length;
    }

    public MeshRenderer[] GetMeshRenderers()
    {
        return renderers;
    }
}
