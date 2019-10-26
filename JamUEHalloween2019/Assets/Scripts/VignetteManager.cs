using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteManager : MonoBehaviour
{
    [SerializeField] float timeBetweenVignetteReductions = 1.0f;
    [SerializeField] float vigentteIncrementPerTick = 0.1f;
    [SerializeField] float startinVignette = 0.2f;

    [SerializeField] PostProcessProfile postProcessingProfile;
    
    float incrementedIntensity = 0.0f;
    Vignette vignette;
    
    void Start()
    {
        postProcessingProfile.TryGetSettings<Vignette>(out vignette);
        vignette.intensity.Override(startinVignette);

        vignette.enabled.Override(true);

        StartCoroutine(IncreaseVignette());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator IncreaseVignette()
    {
        yield return new WaitForSecondsRealtime(timeBetweenVignetteReductions);
        incrementedIntensity += vigentteIncrementPerTick;
        vignette.intensity.Override(incrementedIntensity);
        if(incrementedIntensity < 1f)
            StartCoroutine(IncreaseVignette());
        else
        {
            GameOver.EndGame();
        }
    }
}
