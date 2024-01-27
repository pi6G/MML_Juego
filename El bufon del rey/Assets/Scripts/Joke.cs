using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joke : MonoBehaviour
{
    [SerializeField] private Category category;
    [SerializeField ] [TextArea] private string jokeContent;
    public string JokeContent { get { return jokeContent;  } } 
    public Category Category { get { return category; } }

}
