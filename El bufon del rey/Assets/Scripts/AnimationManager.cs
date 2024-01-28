using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject spriteAnimation;

    //private void Start()
    //{
    //    animator = GetComponentInChildren<Animator>();
    //}
    public void Inicialice()
    {
        StartCoroutine(StartAnimation());
    }
    public IEnumerator StartAnimation() 
    {
        spriteAnimation.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        animator.Play("FKing_DeadAnimation");
    }
}
