using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Declarations

    [Header("References")]
    [SerializeField]
    GameObject mainCamera;

    [SerializeField]
    GameObject directionObj;

    [SerializeField]
    GameObject groundCheck;

    [Header("Movement Variables")]

    [SerializeField]
    float groundCheckRadius;

    [SerializeField]
    float gravityMultiplier;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float jumpForce;

    [SerializeField]
    float groundDrag;

    [SerializeField]
    float airControl;

    [SerializeField]
    float jumpTeleport;

    Vector3 movementValue;

    public bool airborne;
    
    bool moveEnabled;
    bool gravityEnabled;
    
    bool speedLimit;
    bool dragLocked;


    LayerMask mask;
    Rigidbody rb;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mask = LayerMask.GetMask("ground");
        moveEnabled = true;
        gravityEnabled = true;
        speedLimit = true;
        dragLocked = false;
    }

    private void FixedUpdate()
    {
        if (moveEnabled)
        {
            Move();
        }

        if (gravityEnabled)
        {
            Gravity();
        }
    }

    private void Update()
    {
        airborne = true;

        Collider[] colliders = Physics.OverlapSphere(groundCheck.transform.position, groundCheckRadius, mask);

        if (colliders.Length > 0)
        {
            airborne = false;
        }

        if (!airborne)
        {
            ChangeDrag(groundDrag);
        }
        else
        {
            ChangeDrag(0);
        }

        if (speedLimit)
        {
            SpeedControl();
        }

    }

    #region Input Methods

    void OnMove(InputValue value)
    {
        movementValue = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
    }

    void OnJump()
    {
        if (!airborne)
        {
            rb.position += new Vector3(0, jumpTeleport, 0);

            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce);
        }
    }
    #endregion

    #region Movement Functions

    void ChangeDrag(float data)
    {
        if (!dragLocked)
        {
            rb.drag = data;
        }

    }

    void Gravity()
    {
        rb.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }

    void Move()
    {
        if (airborne)
        {
            rb.AddForce((movementValue.x * directionObj.transform.right + movementValue.z * directionObj.transform.forward) * moveSpeed * 10f * airControl, ForceMode.Force);
        }
        else
        {
            rb.AddForce((movementValue.x * directionObj.transform.right + movementValue.z * directionObj.transform.forward) * moveSpeed * 10f, ForceMode.Force);
        }
    }
    #endregion
}
