using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private float scores;
    private TMP_Text text;
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void AddScore(float score)
    {
        scores += score;
        textMesh.text = scores.ToString();
    }
}
