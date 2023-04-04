using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    private Transform tr;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float MoveSpeed;
    private Animator anim;
    public bool attackAble = true;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && attackAble)
        {
            attackAble = false;
            rb.velocity = Vector3.zero;
            anim.SetBool("Attack", true);
            StartCoroutine(AtackTimer());
        }
        if (attackAble)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed, rb.velocity.y);
            if (rb.velocity.x != 0)
            {
                if (rb.velocity.x > 0)
                {
                    anim.SetBool("Run", true);
                    sr.flipX = false;
                }
                if (rb.velocity.x < 0)
                {
                    anim.SetBool("Run", true);
                    sr.flipX = true;
                }
            }
            if (Input.GetButtonUp("Horizontal"))
            {
                Debug.Log("호리존탈 키 업");
                anim.SetBool("Sliding", true);
            }
            if (rb.velocity.x == 0)
            {
                anim.SetBool("Run", false);
                anim.SetBool("Sliding", false);
            }
        }
    }

    IEnumerator AtackTimer()
    {
        yield return new WaitForSeconds(0.2f);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Debug.Log(anim.GetCurrentAnimatorStateInfo(0).length);
        anim.SetBool("Attack", false);
        attackAble = true;
    }
}
