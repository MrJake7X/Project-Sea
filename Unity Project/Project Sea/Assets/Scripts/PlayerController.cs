using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private CharacterController controller;

    private Animator anim;

    private Vector3 moveDirection;
    private Vector2 axis;

    public float speed;
    public float jumpSpeed;
    private bool jump;
    public float gravityMagnitude;

	void Start ()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
	}
	
	void Update ()
    {

        if (controller.isGrounded && !jump)
        {
            moveDirection.y = Physics.gravity.y;
        }
        else
        {
            jump = true;
            moveDirection.y += Physics.gravity.y * gravityMagnitude * Time.deltaTime;
        }

        Vector3 tranformDirection = axis.x * transform.right + axis.y * transform.forward;

        moveDirection.x = tranformDirection.x * speed;
        moveDirection.z = tranformDirection.z * speed;

        controller.Move(moveDirection * Time.deltaTime);

        //transform.Rotate(0, axis.x, 0);

        if (moveDirection.x == 0 && moveDirection.z == 0)
        {
            anim.SetBool("walk", false);
        }
        else
        {
            anim.SetBool("walk", true);
        }
    }

    public void SetAxis(Vector3 naxis)
    {
        axis = naxis;
    }

    public void StartJump()
    {
        if (!controller.isGrounded)
        {
            return;
        }

        moveDirection.y = jumpSpeed;
    }
}