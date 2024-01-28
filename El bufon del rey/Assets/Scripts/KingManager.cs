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
        VerifyMood();
    }
    public void VerifyMood()
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
        yield return new WaitForSeconds(1.7f);
        spriteRenderer.enabled = true;
        for (int i = 0; i < 2; i++)
        {
            spriteIndex+=index;
            spriteRenderer.sprite = sprites[spriteIndex];
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(1f);
        spriteRenderer.enabled = false;
        currentMood = mood;
    }
}
