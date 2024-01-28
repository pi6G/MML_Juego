using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int score = 0;
    public int[] castles = { 1, 2 };
    public Vector3 position = new Vector3(-6.99f, -3.18f, -2.11f);

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void AddScore(int score)
    {
        this.score += score;
    }

    public int GetScore()
    {
        return this.score;
    }

    public bool ValidateCastle(int castleNumber)
    {
        if (castles.Contains(castleNumber))
        {
            return true;
        }
        else return false;
    }

    public void Reset()
    {
        score = 0;
        castles[0] = 1;
        castles[1] = 2;
        position = new Vector3(-6.99f, -3.18f, -2.11f);
    }
}
