using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera mainCamera;
    private bool isFlap = false;
    private float flapForce = 5f;


    protected override void Start()
    {
        base.Start();
        mainCamera = Camera.main;

    }



    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertial = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertial).normalized;

        Vector3 velocity = _rigidbody.velocity;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFlap = true;
        }

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = mainCamera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if(lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Vector3 velocity = _rigidbody.velocity;
        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;
    }
}
