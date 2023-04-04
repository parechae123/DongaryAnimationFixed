using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    Animator Anim;
    private void Start()
    {
        Anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    public void ATKChecker()
    {
        Anim.SetBool("Attack", false);
    }
}
