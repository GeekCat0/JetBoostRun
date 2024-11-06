using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject jetSound;

    public int speed = 15;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    public int jetForce = 1;
    public int jetMax = 1;

    public Transform groundCheck;
    public Transform roofCheck;
    public float groundDistance = 0.4f;
    public float roofDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask roofMask;

    public float slowCooldown = 100f;
    float slowTimer = 100f;
    bool slowed = false;
    bool slowMo = false;
    public GameObject slowIcon;

    Vector3 velocity;
    bool isGrounded;
    bool touchingRoof;
    bool boosted = false;
    bool doubleJump = false;
    bool jumped = true;

    void Start()
    {
        doubleJump = FindObjectOfType<GameManager>().doubleJump;
        slowMo = FindObjectOfType<GameManager>().slowMo;
    }

    void Update()
    {
        if (FindObjectOfType<GameManager>().gameRunning)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            touchingRoof = Physics.CheckSphere(roofCheck.position, roofDistance, roofMask);

            if (isGrounded && velocity.y < -2f)
            {
                velocity.y = -1f;
                boosted = false;
            }
            if (isGrounded && doubleJump) { jumped = false; }


            float x = Input.GetAxis("Horizontal");

            Vector3 move = transform.right * x;

            controller.Move(move * speed * Time.deltaTime);



            if (Input.GetButtonDown("Jump") && (isGrounded || !jumped))
            {
                if (!isGrounded) { jumped = true; }
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            if (Input.GetButton("Jump") && !touchingRoof && velocity.y < jetMax)
            {
                if (velocity.y < 6f)
                {
                    velocity.y += (jetForce * 1.5f) * Time.deltaTime;
                }
                else
                {
                    velocity.y += jetForce * Time.deltaTime;
                }
            }

            if (Input.GetButton("Jump") && !isGrounded)
            {
                jetSound.SetActive(true);
            }
            else
            {
                jetSound.SetActive(false);
            }

            if (slowCooldown < 100f)
            {
                slowCooldown += 10f * Time.deltaTime;
            }
            else if (slowMo)
            {
                slowIcon.SetActive(true);
                if (Input.GetKeyDown(KeyCode.V))
                {
                    Time.timeScale = 0.5f;
                    slowIcon.SetActive(false);
                    slowed = true;
                    slowTimer = 0f;
                    slowCooldown = 0f;
                }
            }
            if (slowed && slowTimer < 10f)
            {
                slowTimer += 5f * Time.deltaTime;
            }
            else if (slowed)
            {
                Time.timeScale = 1f;
                slowed = false;
            }


            else if (Input.GetKeyDown(KeyCode.C) && !boosted && velocity.y > -Mathf.Sqrt(jumpHeight * -2f * gravity))
            {
                velocity.y = -Mathf.Sqrt(jumpHeight * -5f * gravity) + (jetForce * 0.1f);
                boosted = true;
            }


            if (touchingRoof)
            {
                velocity.y = -2f;
            }

            if (!Input.GetButton("Jump"))
            {
                velocity.y += gravity * Time.deltaTime;
            }
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
