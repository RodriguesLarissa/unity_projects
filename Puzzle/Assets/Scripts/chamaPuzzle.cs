using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chamaPuzzle : MonoBehaviour
{
    bool primeira;
    float t;

    void Start() {
        primeira = true;
        t = 0;
    }

    void Update() {
        print(t);
        t += Time.deltaTime;
        if (t > 18 && primeira) {
            primeira = false;
            SceneManager.LoadScene("PuzzleAudios");
        }
    }
}
