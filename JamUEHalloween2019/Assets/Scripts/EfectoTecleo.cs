using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoTecleo : MonoBehaviour
{
    public static AudioClip audioTecleo, audioPaso;
    static AudioSource audioSrc;

    void Start()
    {
        audioTecleo = Resources.Load<AudioClip>("tecla");
        audioPaso = Resources.Load<AudioClip>("paso");//Le asigna al clip audioTecleo el .mp3 que usaremos para esta accion
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void Sonido(string clip)
    {
        switch (clip)
        {//se usa un switch por si se añaden otros efectos de sonido que sean llamados por otros string diferentes
            case "tecla":
                audioSrc.PlayOneShot(audioTecleo);//si se llama a la función con "tecla" se escuchará oof.mp3
                break;
            case "paso":
                audioSrc.PlayOneShot(audioPaso);//si se llama a la función con "tecla" se escuchará oof.mp3
                break;
        }
    }
}
