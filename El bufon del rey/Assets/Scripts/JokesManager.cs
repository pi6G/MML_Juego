using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokesManager : MonoBehaviour
{
    [SerializeField] private ButtonManager[] buttons;
    
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
        foreach (ButtonManager button in buttons)
        {
            button.UpdateJoke(jokes[jokesIndex]);
            jokesIndex++;
        }
    }
}
