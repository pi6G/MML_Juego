using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KingManager : MonoBehaviour
{
    public int mood = 2;
    public int currentMood = 2;
    [Range(0,10)] public int spriteIndex = 4;
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private GameObject[] finalMessages;

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
            StartCoroutine(FinishState());
        }
    }

    public IEnumerator FinishState()
    {
        finalPanel.SetActive(true);
        switch (currentMood)
        {
            case 0:
                finalMessages[0].SetActive(true);
                break;
            case 1:
                finalMessages[1].SetActive(true);
                break;
            case 2:
                finalMessages[2].SetActive(true);
                break;
            case 3:
                finalMessages[3].SetActive(true);
                break;
            case 4:
                finalMessages[4].SetActive(true);
                break;
            case 5:
                finalMessages[5].SetActive(true);
                break;
        }
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("SelectordeNiveles");
    }

}
