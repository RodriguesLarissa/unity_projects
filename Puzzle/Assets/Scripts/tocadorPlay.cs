using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tocadorPlay : MonoBehaviour
{
    AudioSource audio2;

    public void playPlay() {
        audio2 = GetComponent<AudioSource>();
        audio2.Play();
    }
}
