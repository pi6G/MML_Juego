using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    private Joke joke;
    [SerializeField] private TMP_Text textUI;
    
    public void UpdateJoke(Joke joke)
    {
        this.joke = joke;
        textUI.text = joke.GetJokeContent();
    }

    public void MakeTransition()
    {

    }
}
