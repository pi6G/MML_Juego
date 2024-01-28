using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KingManager : MonoBehaviour
{
    public int mood = 2;
    public int currentMood = 2;
    [Range(0,10)] public int spriteIndex = 4;
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
        else
        {
            StartCoroutine(Animation(0));
        }
    }

    public IEnumerator Animation(int index)
    {
        yield return new WaitForSeconds(1.7f);
        if (!(spriteIndex == 0 && index < 0))
        {
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(1f);
            if (!(spriteIndex == 10 && index > 0))
            {
                for (int i = 0; i < 2; i++)
                {
                    yield return new WaitForSeconds(0.1f);
                    spriteIndex += index;
                    spriteRenderer.sprite = sprites[spriteIndex];
                    //yield return new WaitForSeconds(1.5f);
                }
                yield return new WaitForSeconds(1f);
                currentMood = mood;
            }
            else
            {
               yield return new WaitForSeconds(2);
            }
            spriteRenderer.enabled = false;
        }
        else
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("SelectordeNiveles");
        }
    }
}
