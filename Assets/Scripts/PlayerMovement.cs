using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float movementSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lookInput;
    private Vector2 lastLook;

    private PlayerFOV fov;

    private MenuHandle pauseMenu;

    private Animator animator;
    private bool inputAllowed = true;
    private const string WALK_RIGHT = "WalkRight";
    private const string WALK_LEFT = "WalkLeft";
    private const string WALK_UP = "WalkUp";
    private const string WALK_DOWN = "WalkDown";
    private const string DEFEAT = "Defeat";


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fov = GameObject.FindGameObjectWithTag("FOV").GetComponent<PlayerFOV>();
        animator = GetComponent<Animator>();
        pauseMenu = GameObject.FindGameObjectWithTag("Pause").GetComponent<MenuHandle>();
        pauseMenu.ClosePauseMenu();

        fov.SetOrigin(transform.position);
        fov.SetFOVDirection(Vector3.right);

        if (PlayerPrefs.GetString("Controls").Equals(MenuHandle.KEYBOARD_AND_MOUSE_CONTROLS))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        fov.UpdateFOVUpgrades(false);
    }

    // Update is called once per frame
    void Update()
    {
        //check for pause input
        if (Input.GetKeyDown(KeyCode.Escape) && inputAllowed)
        {
            if (Time.timeScale > 0f)
            {
                pauseMenu.OpenPauseMenu();
            }
            else
            {
                pauseMenu.ClosePauseMenu();
            }
        }

        if (inputAllowed && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }

        if(inputAllowed && Time.timeScale > 0)
        {

            fov.SetOrigin(transform.position);

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement = movement.normalized;

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
            animator.enabled = true;
            if (movement.y != 0)
            {
                if (movement.y > 0) // moving up
                {
                    animator.Play(WALK_UP);

                }
                else //moving down
                {
                    animator.Play(WALK_DOWN);
                }

            }
            else if (movement.x != 0)
            {
                if (movement.x > 0) // moving right
                {
                    animator.Play(WALK_RIGHT);
                }
                else //moving left
                {
                    animator.Play(WALK_LEFT);
                }
            }
            else
            {
                animator.enabled = false;
            }

            fov.SetFOVDirection(lastLook);
        }
    }

    public void IsDefeated()
    {
        animator.enabled = true;
        inputAllowed = false;
        movement = Vector2.zero;
        fov.gameObject.SetActive(false);
        animator.Play(DEFEAT);
        Invoke("Restart", 2f);
    }

    public void SetInputPermission(bool state)
    {
        inputAllowed = state;
    }

    private void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * movementSpeed * Time.fixedDeltaTime));
    }
}
