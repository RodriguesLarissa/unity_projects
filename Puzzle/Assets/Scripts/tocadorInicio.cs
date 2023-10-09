using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tocadorInicio : MonoBehaviour
{
    AudioSource audio1;
    
    public void playInicio() {
        audio1 = GetComponent<AudioSource>();
        audio1.Play();
    }
}
