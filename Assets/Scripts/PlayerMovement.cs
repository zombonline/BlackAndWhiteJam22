using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private PlayerFOV fov;

    private SpriteRenderer spriteRenderer;

    public Sprite upMove;
    public Sprite downMove;
    public Sprite rightMove;
    public Sprite leftMove;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fov = GameObject.FindGameObjectWithTag("FOV").GetComponent<PlayerFOV>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        fov.SetOrigin(transform.position);
        fov.SetFOVDirection(Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        fov.SetOrigin(transform.position);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.y != 0)
        {
            if (movement.y > 0) // moving up
            {
                spriteRenderer.sprite = upMove;
                fov.SetFOVDirection(Vector3.up);
            }
            else //moving down
            {
                spriteRenderer.sprite = downMove;
                fov.SetFOVDirection(Vector3.down);
            }

        }else if (movement.x != 0)
        {
            if (movement.x > 0) // moving right
            {
                spriteRenderer.sprite = rightMove;
                fov.SetFOVDirection(Vector3.right);
            }
            else //moving left
            {
                spriteRenderer.sprite = leftMove;
                fov.SetFOVDirection(Vector3.left);
            }
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * movementSpeed * Time.fixedDeltaTime));
    }
}
