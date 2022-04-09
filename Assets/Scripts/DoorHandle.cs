using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    [SerializeField]
    private int id = 0;
    private Animator animator;
    private BoxCollider2D boxCollider;

    [SerializeField]
    private bool reversed;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        animator.enabled = false;
        if (reversed)
        {
            animator.enabled = true;
            boxCollider.enabled = false;
            //pause animation to prevent reverse delays
            Invoke("PauseAnimation", 0.5f);
        }
        
    }

    public int GetID()
    {
        return id;
    }

    public void OpenDoor()
    {
        if (!reversed)
        {
            animator.enabled = true;
            boxCollider.enabled = false;
        }
        else
        {
            animator.StartPlayback();
            animator.speed = -1;
            animator.enabled = true;
            boxCollider.enabled = true;
        }
        
    }

    private void PauseAnimation()
    {
        animator.enabled = false;
    }
}
