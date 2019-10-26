using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveObject : MonoBehaviour
{
    public bool canInteract = false;
    [SerializeField] float interactiveRadious = 3.0f;
    [SerializeField] UnityEvent onInteraction;

    MovimientoPersonaje player;

    bool interacted = false;
    
    void Start()
    {
        player = FindObjectOfType<MovimientoPersonaje>();
    }

    
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= interactiveRadious)
            canInteract = true;
        else
            canInteract = false;
    }

    public void Interaction()
    {
        if(canInteract)
            Debug.Log(this);
            onInteraction.Invoke();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactiveRadious);
    }
}
