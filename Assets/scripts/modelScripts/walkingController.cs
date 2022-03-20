using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FacingDirection {
    North,
    East,
    South,
    West
}

public class walkingController : Controller
{
    Vector3 walkVelocity;
    Vector3 prevWalkVelocity;
    FacingDirection facing;
    float adjVerVelocity;
    float jumpPressTime;

    public float walkSpeed = 2.5f;
    public float jumpSpeed = 5f;

    public override void ReadInput(InputData data)
    {
        prevWalkVelocity = walkVelocity;
        ResetMovementtoZero();

        // set vertical movement
        if (data.axes[0] != 0f){
            walkVelocity += Vector3.forward * data.axes[0]* walkSpeed;
        }
        // set horizontal movement
        if (data.axes[1] != 0f)
        {
            walkVelocity += Vector3.right * data.axes[1]* walkSpeed;
        }
        // set vertical jump
        if (data.buttons[0] == true){
            if (jumpPressTime == 0f){
                if (Grounded()) {
                    adjVerVelocity = jumpSpeed;
                }               
            }
            jumpPressTime = Time.deltaTime;
        } else {
            jumpPressTime = 0f;
        }
        newInput = true;
    }

    bool Grounded() {
        return Physics.Raycast(transform.position, Vector3.down, coll.bounds.extents.y + 0.1f);
    }

    private void LateUpdate()
    {
        if (!newInput){
            prevWalkVelocity = walkVelocity;
            ResetMovementtoZero();
            jumpPressTime = 0f;
        }
        if (prevWalkVelocity != walkVelocity) {
            CheckForFacingChange();
        }
        rb.velocity = new Vector3(walkVelocity.x, rb.velocity.y + adjVerVelocity, walkVelocity.z);
        newInput = false;
    }

    void CheckForFacingChange() {
        if (walkVelocity == Vector3.zero) {
            return;
        }
        if (walkVelocity.x == 0 || walkVelocity.z == 0) {
            ChangeFacing(walkVelocity);
        } else
        {
            if (prevWalkVelocity.x == 0)
            {
                ChangeFacing(new Vector3(walkVelocity.x, 0, 0));
            }
            else if (prevWalkVelocity.z == 0) {
                ChangeFacing(new Vector3(0, 0, walkVelocity.z));
            } else
            {
                Debug.LogWarning("Unexpected walkVelocity value");
                ChangeFacing(walkVelocity);
            }
        }
    }

    void ChangeFacing(Vector3 dir) {
        if (dir.z != 0)
        {
            facing = (dir.z > 0) ? FacingDirection.North : FacingDirection.South;
        }
        else { 
            facing = (dir.x > 0) ? FacingDirection.East : FacingDirection.West;
        }

        Debug.Log(facing);
    }

    private void ResetMovementtoZero()
    {
        walkVelocity = Vector3.zero;
        adjVerVelocity = 0f;
    }
}
