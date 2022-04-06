using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    [SerializeField]
    private int id = 0;
    private Animator animator;
    private BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    public int GetID()
    {
        return id;
    }

    public void OpenDoor()
    {
        animator.enabled = true;
        collider.enabled = false;
    }
}
