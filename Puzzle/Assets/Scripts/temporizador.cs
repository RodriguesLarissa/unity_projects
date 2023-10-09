using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class temporizador : MonoBehaviour
{
    public float tempo = 0f;
    private TMP_Text textoTemporizador;

    public void iniciaTempo() {
        textoTemporizador = GetComponent<TMP_Text>();
        tempo += Time.deltaTime;
        atualizarTextoTemporizador();
    }

    public void zerarTemporizador() {
        tempo = 0;
    }

    void atualizarTextoTemporizador()
    {
        int minutos = Mathf.FloorToInt(tempo / 60f);
        int segundos = Mathf.FloorToInt(tempo % 60f);

        textoTemporizador.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
