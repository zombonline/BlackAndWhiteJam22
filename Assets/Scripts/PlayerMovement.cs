using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lookInput;
    private Vector2 lastLook;

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

        if (PlayerPrefs.GetString("Controls").Equals(MenuHandle.KEYBOARD_AND_MOUSE_CONTROLS))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    // Update is called once per frame
    void Update()
    {
        fov.SetOrigin(transform.position);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //check controls options
        if (PlayerPrefs.GetString("Controls").Equals(MenuHandle.KEYBOARD_CONTROLS))
        {
            lookInput.x = Input.GetAxisRaw("Look_Horizontal");
            lookInput.y = Input.GetAxisRaw("Look_Vertical");

            if (lookInput != Vector2.zero)
            {
                lastLook = lookInput;
            }
        }
        else
        {
            lastLook = Camera.main.ScreenPointToRay(Input.mousePosition).origin - transform.position;
        }

        if (movement.y != 0)
        {
            if (movement.y > 0) // moving up
            {
                spriteRenderer.sprite = upMove;
                
            }
            else //moving down
            {
                spriteRenderer.sprite = downMove;
            }

        }else if (movement.x != 0)
        {
            if (movement.x > 0) // moving right
            {
                spriteRenderer.sprite = rightMove;
            }
            else //moving left
            {
                spriteRenderer.sprite = leftMove;
            }
        }

        fov.SetFOVDirection(lastLook);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * movementSpeed * Time.fixedDeltaTime));
    }
}
