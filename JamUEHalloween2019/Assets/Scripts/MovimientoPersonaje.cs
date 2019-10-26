using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    Animator anim;
    [SerializeField] float speed = 100f;
    [SerializeField] float maxSpeed = 20f;
    Rigidbody rigidBody;
    float xThrow;
    float yThrow;
    Vector2 movementDir;

    Camera camera;

    Vector3 cameraRight;
    Vector3 cameraForward;

    public bool writing = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        anim = this.gameObject.GetComponent<Animator>();

        anim.gameObject.SetActive(true);

        camera = FindObjectOfType<Camera>();

        cameraForward = Vector3.ProjectOnPlane(camera.transform.forward, new Vector3(0, 1, 0)).normalized;
        cameraRight = Vector3.ProjectOnPlane(camera.transform.right, new Vector3(0, 1, 0)).normalized;
    }

    void Update()
    {
        if (!writing)
        {
            cameraForward = Vector3.ProjectOnPlane(camera.transform.forward, new Vector3(0, 1, 0)).normalized;
            cameraRight = Vector3.ProjectOnPlane(camera.transform.right, new Vector3(0, 1, 0)).normalized;

            xThrow = Input.GetAxisRaw("Horizontal");
            yThrow = Input.GetAxisRaw("Vertical");

            movementDir = new Vector3(xThrow, yThrow).normalized;

            Movement();
            sentarse();
        }
    }

    void Movement()
    {
        Vector3 forwardMovement = calculateForwardMovement();

        float auxY = rigidBody.velocity.y;

        rigidBody.velocity = ((movementDir.x * cameraRight).normalized + forwardMovement.normalized) * speed;

        rigidBody.velocity = new Vector3(rigidBody.velocity.x, auxY, rigidBody.velocity.z);

        if(rigidBody.velocity.magnitude > 0) transform.forward = rigidBody.velocity.normalized;

        if (rigidBody.velocity.magnitude > maxSpeed)
        {
            float offset = (rigidBody.velocity.magnitude - speed) / 2f;

            rigidBody.velocity = new Vector3(rigidBody.velocity.x - offset * Mathf.Sign(rigidBody.velocity.x),
                                             0f,
                                             rigidBody.velocity.z - offset * Mathf.Sign(rigidBody.velocity.z));
        }

        if (rigidBody.velocity.magnitude > 0) anim.SetBool("walk", true);
        else anim.SetBool("walk", false);
    }
    void sentarse()
    {
        if (Input.GetKey(KeyCode.T))
        {
            anim.SetBool("sit", true);
        }
        if (Input.GetKey(KeyCode.Y))
        {
            anim.SetBool("sit", false);
        }
    }

    Vector3 calculateForwardMovement()
    {
        RaycastHit hit;
        Vector3 planeNormal = Vector3.zero;

        int mask = LayerMask.GetMask("Default");

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1, mask))
        {
            planeNormal = hit.normal;
        }

        Vector3 forwardMovement = Vector3.ProjectOnPlane((movementDir.y * cameraForward), planeNormal);
        return forwardMovement;
    }

    public void setWriting(bool b)
    {
        writing = b;
    }
}
