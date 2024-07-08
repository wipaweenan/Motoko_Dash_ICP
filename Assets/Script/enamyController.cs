using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enamyController : MonoBehaviour
{
    private CharacterController Controller;
    private Vector3 direction;
    public float forwardSpeed;



    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;
    }

    private void FixedUpdate()
    {
        Controller.Move(direction * Time.fixedDeltaTime);
    }

}
