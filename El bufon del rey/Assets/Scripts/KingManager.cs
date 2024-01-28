using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingManager : MonoBehaviour
{
    public int mood = 2;
    public int currentMood = 2;
    public int spriteIndex = 4;
    public GameObject king;
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        //sprites = new Sprite[11];

        //for (int i = 0; i < 11; i++)
        //{
        //    string spriteName = "FKing_" + (i); 
        //    sprites[i] = Resources.Load<Sprite>("Sprites/Kings" + spriteName + ".asset"); 
        //    Debug.Log(spriteName);
        //}
    }
    public void ModifyMood(Category category)
    {
        switch (category)
        {
            case Category.GOOD:
                mood++;
                break;
            case Category.BAD:
                mood--;
                break;
        }
    }
    public void VerifyMood(int mood)
    {
        if(mood > currentMood)
        {
            StartCoroutine(Animation(1));
        } else if (mood < currentMood)
        {
            StartCoroutine(Animation(-1));
        }
    }

    public IEnumerator Animation(int index)
    {
        for (int i = 0; i < 2; i++)
        {
            spriteIndex+=index;
            spriteRenderer.sprite = sprites[spriteIndex];
            yield return new WaitForSeconds(1);             

        }
    }
}
