using System;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public  float FORWARD_MOVE_SPEED = 15f;

    public  float ROTATION_MOVE_SPEED = 150f;

    public Rigidbody rigidBody;

    public float currentForwardSpeed;
    public float currentRotationSpeed;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();

    }
    

    void FixedUpdate()
    {
        currentForwardSpeed = Input.GetAxis("Vertical");
        currentRotationSpeed = Input.GetAxis("Horizontal");


        ActiveMoving();
    }
    
    private void ActiveMoving()
    {
        if (!areButtonsPressed())
        {
            rigidBody.isKinematic = true;
        }
        else
        {
            rigidBody.isKinematic = false;
            forwardMove();
            rotationMove();
        }
    }

    private bool areButtonsPressed()
    {
        return Input.GetButton("Vertical") || Input.GetButton("Horizontal");
    }

    private void forwardMove()
    {
        Vector3 movement = transform.forward * FORWARD_MOVE_SPEED * Time.deltaTime * currentForwardSpeed;
        rigidBody.MovePosition(rigidBody.position + movement);
    }

    private void rotationMove()
    {
        float turn = currentRotationSpeed * ROTATION_MOVE_SPEED * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rigidBody.MoveRotation(rigidBody.rotation * turnRotation);
    }
}
