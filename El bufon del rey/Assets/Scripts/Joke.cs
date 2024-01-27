using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joke : MonoBehaviour
{
    [SerializeField] private Category category;
    [SerializeField ]private string jokeContent;
    public string GetJokeContent() {  return jokeContent; }

}
