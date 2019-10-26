using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Annoyance : MonoBehaviour
{
    [SerializeField] UnityEvent onAnnoyanceTrigger;
    [SerializeField] UnityEvent onAnnoyanceResolve;
    [SerializeField] SpriteRenderer thouhgtBubble;
    [SerializeField] MaquinaDeEscribir typingMachine;
    MovimientoPersonaje player;

    private void Start()
    {
        player = FindObjectOfType<MovimientoPersonaje>();
    }

    public void TriggerAnnoyance()
    {
        thouhgtBubble.gameObject.SetActive(true);
        typingMachine.annoyed = true;
        onAnnoyanceTrigger.Invoke();
    }

    public void AnnoyanceResolved()
    {
        thouhgtBubble.gameObject.SetActive(false);
        typingMachine.annoyed = false;
        onAnnoyanceResolve.Invoke();
    }
}
