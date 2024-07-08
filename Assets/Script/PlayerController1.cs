using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private CharacterController Controller;
    private Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1;
    public int laneDistance = 4;

    public float jumpForce;
    public float Gravity = -10;
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;

        if (Controller.isGrounded)
        {
            direction.y = -1;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Jump");
                Jump();
            }
        }else 
        {
            direction.y += Gravity * Time.deltaTime;
        }
        

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("GoRight");
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("GoLeft");
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
       

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            Controller.Move(moveDir);
        else
            Controller.Move(diff);

    }
    private void FixedUpdate()
    {
        Controller.Move(direction * Time.deltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            Debug.Log("Hit");
            PlayerManager.gameOver = true;
        }
    }
}
