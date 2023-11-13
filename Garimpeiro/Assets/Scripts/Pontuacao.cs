using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pontuacao : MonoBehaviour
{
    void Start()
    {
        AtualizarPontuacao();
    }

    void AtualizarPontuacao()
    {
        // Supondo que este script está associado a um GameObject com o nome no formato "PontuacaoX"
        // onde X é o número da pontuação.
        string nomeGameObject = gameObject.name;

        // Obtém o número do GameObject
        int numeroPontuacao;
        if (int.TryParse(nomeGameObject.Substring("Pontuacao".Length), out numeroPontuacao))
        {
            // Ajusta o índice para corresponder à posição no array
            int indice = numeroPontuacao - 1;

            // Verifica se o índice é válido para evitar índices negativos
            if (indice >= 0 && indice < ScoreManager.TOP_3_SCORES.Length)
            {
                // Atualiza o texto diretamente no GameObject
                GetComponent<TextMeshProUGUI>().text = ScoreManager.TOP_3_SCORES[indice].ToString();
            }
            else
            {
                Debug.LogError("Índice de pontuação inválido: " + indice);
            }
        }
        else
        {
            Debug.LogError("Não foi possível extrair o número de pontuação do nome do GameObject: " + nomeGameObject);
        }
    }
}
