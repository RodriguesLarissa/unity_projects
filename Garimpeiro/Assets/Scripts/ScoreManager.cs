using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum eScoreEvent
{
    monte,
    mina,
    minaOutro,
    gameVitoria,
    gameDerrota,
    modoGold,
    modoDuploGold
}

public class ScoreManager : MonoBehaviour
{
    static private ScoreManager S;

    static public int SCORE_DA_PARTIDA_ANTERIOR = 0;
    static public int[] TOP_3_SCORES = new int[3]; // Array para armazenar os 3 maiores scores
    static public int HIGH_SCORE = 0;

    [Header("Set Dynamically")]
    public int serie = 0;
    public int scoreRodada = 0;
    public int score = 0;

    bool modoGold = false;
    bool modoDuploGold = false;
    TMP_Text scoreText;
    private AudioSource audioSource;

    private void Awake()
    {
        if (S == null) {
            S = this;
        }
        else {
            Debug.LogError("ScoreManager.Awake(): S já existe!");
        }
        if (PlayerPrefs.HasKey("GarimpeiroHighScore")) {
            HIGH_SCORE = PlayerPrefs.GetInt("GarimpeiroHighScore");
        }
        LoadTopScores(); // Carrega os 3 maiores scores do PlayerPrefs
        score += SCORE_DA_PARTIDA_ANTERIOR;
        SCORE_DA_PARTIDA_ANTERIOR = 0;
        S.scoreText = GetComponent<TMP_Text>();
    }

    private void Start() {
        S.scoreText.text = "Inicio, Record Atual = " + HIGH_SCORE;
        audioSource = GetComponent<AudioSource>();
    }

    static public void EVENT(eScoreEvent evt) {
        try {
            S.Event(evt);
        } catch(System.NullReferenceException nre) {
            Debug.LogError("ScoreManager:EVENT() Chamado enquanto S = null.\n" + nre);
        }
    }

    void Event(eScoreEvent evt) {
        switch (evt) {
            case eScoreEvent.monte:
            case eScoreEvent.gameVitoria:
            case eScoreEvent.gameDerrota:
                serie = 0;
                if (modoDuploGold) scoreRodada *= 4;
                else if (modoGold) scoreRodada *= 2;
                score += scoreRodada;
                scoreRodada = 0;
                break;
            case eScoreEvent.mina:
                serie++;
                scoreRodada += serie;
                audioSource.Play();
                break;
            case eScoreEvent.modoGold:
                modoGold = true;
                break;
            case eScoreEvent.modoDuploGold:
                modoDuploGold = true;
                break;
        }

        switch (evt) {
            case eScoreEvent.gameVitoria:
                SCORE_DA_PARTIDA_ANTERIOR = score;
                CheckAndUpdateTopScores(score); // Verifica e atualiza os 3 maiores scores
                SaveTopScores(); // Salva os 3 maiores scores no PlayerPrefs
                print("VITÓRIA! Pontos desta Partida: " + score);
                break;

            case eScoreEvent.gameDerrota:
                if(HIGH_SCORE <= score) {
                    print("Você teve uma pontuação alta! High score: " + score);
                } else {
                    print("Sua pontuação no game foi: " + score);
                }
                break;

            default:
                scoreText.text = "Total: " + score.ToString() +
                                    " da rodada:" + scoreRodada.ToString() +
                                    ", série: " + serie.ToString();
                break;
        }
    }

    void CheckAndUpdateTopScores(int currentScore) {
        // Verifica se o score atual está entre os 3 maiores scores
        for (int i = 0; i < TOP_3_SCORES.Length; i++) {
            if (currentScore > TOP_3_SCORES[i]) {
                // Se sim, desloca os outros scores e insere o novo score
                for (int j = TOP_3_SCORES.Length - 1; j > i; j--) {
                    TOP_3_SCORES[j] = TOP_3_SCORES[j - 1];
                }
                TOP_3_SCORES[i] = currentScore;
                break;
            }
        }
    }

    void LoadTopScores() {
        for (int i = 0; i < TOP_3_SCORES.Length; i++) {
            if (PlayerPrefs.HasKey("TopScore" + i)) {
                TOP_3_SCORES[i] = PlayerPrefs.GetInt("TopScore" + i);
            }
        }
    }

    void SaveTopScores() {
        for (int i = 0; i < TOP_3_SCORES.Length; i++) {
            PlayerPrefs.SetInt("TopScore" + i, TOP_3_SCORES[i]);
        }
    }
}
