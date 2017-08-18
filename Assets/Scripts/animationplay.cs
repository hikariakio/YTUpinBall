using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationplay : MonoBehaviour {

    static Animator anim;

    void Start () {
        anim = GetComponent<Animator>();
    }

    public static void  GameOverAnimation()
    {
        anim.SetTrigger("GameOver");
    }		
}
