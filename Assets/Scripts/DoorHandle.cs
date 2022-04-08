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
        if (!reversed)
        {
            animator.enabled = false;
        }
        else
        {
            boxCollider.enabled = false;
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
            boxCollider.enabled = true;
        }
        
    }
}
