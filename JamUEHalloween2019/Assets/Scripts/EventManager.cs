using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] GameObject deadSoldier;
    [SerializeField] float timeToDeadSoldier;

    Annoyance[] annoyances;

    [SerializeField] float minTimeUntilNextAnnoyance = 120f;
    [SerializeField] float maxTimeUntilNextAnnoyance = 180f;

    void Start()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;
        annoyances = FindObjectsOfType<Annoyance>();
        StartCoroutine(TriggerNextAnnoyance());
        StartCoroutine(SpawnDeadSoldier());
    }

    public void TriggerNextAnnoyanceWrapper()
    {
        StartCoroutine(TriggerNextAnnoyance());
    }

    public IEnumerator TriggerNextAnnoyance()
    {
        yield return new WaitForSecondsRealtime(Random.Range(minTimeUntilNextAnnoyance, maxTimeUntilNextAnnoyance));
        annoyances[Random.Range(0, annoyances.Length)].TriggerAnnoyance();
    }

    IEnumerator SpawnDeadSoldier()
    {
        yield return new WaitForSecondsRealtime(timeToDeadSoldier);
        deadSoldier.gameObject.SetActive(true);
    }
}
