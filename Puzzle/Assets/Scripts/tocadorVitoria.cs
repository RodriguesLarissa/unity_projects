using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tocadorVitoria : MonoBehaviour
{
    AudioSource audio3;
    
    public void playVitoria() {
        audio3 = GetComponent<AudioSource>();
        audio3.Play();
    }
}
