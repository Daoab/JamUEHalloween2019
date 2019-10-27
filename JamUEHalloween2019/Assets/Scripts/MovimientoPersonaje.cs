using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    Animator anim;
    [SerializeField] float speed = 100f;
    [SerializeField] float maxSpeed = 20f;
    [SerializeField] Transform chairTransform;
    [SerializeField] Vector3 sitPosition;
    [SerializeField] Vector3 getUpPosition;

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
        if(b)
        {
            anim.SetBool("walk", false);
            anim.SetBool("sit", true);
            transform.position = sitPosition;
            transform.forward = chairTransform.up;
            GetComponent<BoxCollider>().enabled = false;
            rigidBody.constraints = RigidbodyConstraints.FreezePosition;
        }
        else
        {
            anim.SetBool("sit", false);
            anim.SetBool("walk", false);
            GetComponent<BoxCollider>().enabled = true;
            transform.position = getUpPosition;
            rigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        }
    }
}
