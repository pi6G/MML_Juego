using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    [SerializeField] private Joke[] jokesList;

    public Joke[] GetJokes() { return jokesList; }
}
