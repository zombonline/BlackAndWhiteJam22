using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDebuff : MonoBehaviour
{
    private PlayerMovement movement;
    [SerializeField]
    private bool applying;

    // Start is called before the first frame update
    void Start()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            movement.MovementDebuff(applying);
            GetComponent<EraseTile>().Erase();
        }
    }
}
