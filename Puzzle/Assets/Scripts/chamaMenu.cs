using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chamaMenu : MonoBehaviour
{
    public void AbrirGame() {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
