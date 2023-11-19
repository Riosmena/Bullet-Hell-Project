using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnim;
    public float speed = 5.0f;
    public float turnSpeed = 2.0f;
    public float runSpeed = 15.0f;
    public float horizontalInput;
    public float forwardInput;
    public bool walking;
    public bool isRunning;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * turnSpeed);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerAnim.SetTrigger("walkFront");
            playerAnim.ResetTrigger("idle");
            walking = true;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerAnim.SetTrigger("walkBack");
            playerAnim.ResetTrigger("idle");
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerAnim.SetTrigger("walkRight");
            playerAnim.ResetTrigger("idle");
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerAnim.SetTrigger("walkLeft");
            playerAnim.ResetTrigger("idle");
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            playerAnim.ResetTrigger("walkFront");
            playerAnim.SetTrigger("idle");
            walking = false;
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            playerAnim.ResetTrigger("walkBack");
            playerAnim.SetTrigger("idle");
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            playerAnim.ResetTrigger("walkRight");
            playerAnim.SetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            playerAnim.ResetTrigger("walkLeft");
            playerAnim.SetTrigger("idle");
        }

        if (walking == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isRunning = true;
                playerAnim.SetTrigger("Run");
                playerAnim.ResetTrigger("walkFront");
                transform.Translate(Vector3.forward * Time.deltaTime * runSpeed * forwardInput);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isRunning = false;
                playerAnim.ResetTrigger("Run");
                playerAnim.SetTrigger("walkFront");
                transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            }
        }
    }

    public bool IsRunning()
    {
        return isRunning;
    }
}
