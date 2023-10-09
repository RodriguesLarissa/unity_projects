using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chamaAbertura : MonoBehaviour
{
    public void AbrirGame() {
        SceneManager.LoadScene("Abertura");
    }
}
