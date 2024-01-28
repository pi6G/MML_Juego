using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class MovLvlSelector : MonoBehaviour
{
    [SerializeField] Transform[] castle;


    //Function to be used at the moment of click at the button of each castle.
    public void ToCastle1()
    {
        transform.DOMove(castle[0].position, 1).SetEase(Ease.OutCubic);
        StartCoroutine(Castle1());
    }
    public void ToCastle2()
    {
        transform.DOMove(castle[1].position, 1).SetEase(Ease.OutCubic);
        StartCoroutine(Castle2());
    }

    public void ToCastle3()
    {
        transform.DOMove(castle[2].position, 1).SetEase(Ease.OutCubic);
        StartCoroutine(Castle3());
    }

    IEnumerator Castle1() 
    {
        yield return new WaitForSeconds(1.5f);
        if (ScoreManager.Instance.ValidateCastle(1))
        {
            ScoreManager.Instance.castles[0] = 0;
            SceneManager.LoadScene("BigKing");
        }
    }

    IEnumerator Castle2()
    {
        yield return new WaitForSeconds(1.5f);
        if (ScoreManager.Instance.ValidateCastle(2))
        {
            ScoreManager.Instance.castles[1] = 0;
            SceneManager.LoadScene("BigKing");
        }
    }

    IEnumerator Castle3()
    {
        yield return new WaitForSeconds(1.5f);
        if (ScoreManager.Instance.ValidateCastle(3))
        {
            ScoreManager.Instance.castles[2] = 0;
            SceneManager.LoadScene("BigKing");
        }
    }
}
