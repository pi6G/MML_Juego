using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCas1 : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("BigKing");
    }
}
