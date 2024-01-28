using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JokesManager : MonoBehaviour
{
    [SerializeField] private ButtonManager[] buttons;
    [SerializeField] private GameObject askObject;
    [SerializeField] private TMP_Text askText;
    
    private Joke[] jokes;
    private int jokesIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        //Obtener la referencia del rey y sus chistes
        GameObject kingObject = GameObject.FindGameObjectWithTag("King");
        if (kingObject != null )
        {
            jokes = kingObject.GetComponent<King>().GetJokes();
        }

        UpdateButtons();
    }


    //Funcion para actualizar cada panel con el chiste correspondiente
    public void UpdateButtons()
    {
        
        if (jokesIndex < jokes.Length)
        {
            //Comprobar si el chiste que sigue es de tipo pregunta
            if (jokes[jokesIndex].Category == Category.ASK)
            {
                askObject.SetActive(true);
                askText.text = jokes[jokesIndex].JokeContent;
                jokesIndex++;

            }
            else
            {
                askObject.SetActive(false);
            }


            foreach (ButtonManager button in buttons)
            {
                button.UpdateJoke(jokes[jokesIndex]);
                jokesIndex++;
            }
        }
        else
        {
            ChangeVisibleButtons();
            StartCoroutine(ReturnMap());
        }
    }

    IEnumerator ReturnMap()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("SelectordeNiveles");
    }

    public void ChangeVisibleButtons()
    {
        askObject.SetActive(false);
        foreach (ButtonManager button in buttons)
        {
            button.gameObject.SetActive(!button.gameObject.activeSelf);
        }

    }
}
