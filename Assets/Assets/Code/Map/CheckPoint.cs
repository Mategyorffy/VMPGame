using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Animator CpAnim;
    public void Test()
    {
        CpAnim.SetTrigger("Anim");
    }

    
}
