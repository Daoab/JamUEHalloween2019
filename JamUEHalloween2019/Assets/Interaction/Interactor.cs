using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    InteractiveObject[] interactiveObjects;
    [SerializeField] InteractiveObject closestInteractive;

    
    void Start()
    {
        interactiveObjects = FindObjectsOfType<InteractiveObject>();
        closestInteractive = interactiveObjects[0];
    }

    
    void Update()
    {
        GetClosestInteracitveObject();

        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (closestInteractive.canInteract)
            {
                closestInteractive.Interaction();
            }
        }

    }

    void GetClosestInteracitveObject()
    {
        for (int i = 0; i < interactiveObjects.Length; i++)
        {
            if (Vector3.Distance(transform.position, interactiveObjects[i].transform.position) <
                Vector3.Distance(transform.position, closestInteractive.transform.position))
            {
                closestInteractive = interactiveObjects[i];
            }
        }
    }
}
