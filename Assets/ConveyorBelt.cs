using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    private PlayerMovement movement;
    private float powerMultiplier = 0.5f;
    [SerializeField] private Vector2 direction = Vector2.right;

    // Start is called before the first frame update
    void Start()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        switch (direction)
        {
            case Vector2 v when v.Equals(Vector2.down):
                transform.localRotation = Quaternion.Euler(0,0,-90);
                break;

            case Vector2 v when v.Equals(Vector2.left):
                transform.localRotation = Quaternion.Euler(0, 0, 180);
                break;

            case Vector2 v when v.Equals(Vector2.right):
                transform.localRotation = Quaternion.Euler(Vector3.zero);
                break;

            case Vector2 v when v.Equals(Vector2.up):
                transform.localRotation = Quaternion.Euler(0, 0, 90);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            movement.AddMovementForce(direction * powerMultiplier);
        }
    }
}
