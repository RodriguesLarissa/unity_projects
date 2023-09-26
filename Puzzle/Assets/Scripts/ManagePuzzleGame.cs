using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagePuzzleGame : MonoBehaviour
{   
    public Image parte;
    public Image localMarcado;
    float lmLargura, lmAltura;

    void criarLocaisMarcados() {
        lmLargura = 100; lmAltura = 100;
        float numLinhas = 5; float numColunas = 5;
        float linha, coluna;
        for (int i = 0; i < 25; i++) {
            Vector3 posicaoCentro = new Vector3();
            posicaoCentro = GameObject.Find("ladoDireito").transform.position;
            linha = i % 5;
            coluna = i / 5;
            Vector3 lmPosicao = new Vector3(posicaoCentro.x + lmLargura * (linha - numLinhas / 2),
                posicaoCentro.y - lmAltura * (coluna - numColunas / 2),
                posicaoCentro.z);
            Image lm = (Image)(Instantiate(localMarcado, lmPosicao, Quaternion.identity));
            lm.tag = "" + (i + 1);
            lm.name = "LM" + (i + 1);
            lm.transform.SetParent(GameObject.Find("Canvas").transform);
        }
    }

    void criarPartes() {
        lmLargura = 100;
        lmAltura = 100;
        float numLinhas, numColunas;
        numLinhas = numColunas = 5;
        float linha, coluna;

        for (int i = 0; i < 25; i++) {
            Vector3 posicaoCentro = new Vector3();
            posicaoCentro = GameObject.Find("ladoEsquerdo").transform.position;
            linha = i % 5;
            coluna = i / 5;
            Vector3 lmPosicao = new Vector3(posicaoCentro.x + lmLargura * (linha - numLinhas / 2),
                posicaoCentro.y - lmAltura * (coluna - numColunas / 2),
                posicaoCentro.z);
            Image lm = (Image)(Instantiate(localMarcado, lmPosicao, Quaternion.identity));
            lm.tag = "" + (i + 1);
            lm.name = "Parte" + (i + 1);
            lm.transform.SetParent(GameObject.Find("Canvas").transform);
            Sprite[] todasSprites = Resources.LoadAll<Sprite>("leao");
            Sprite s1 = todasSprites[i];
            lm.GetComponent<Image>().sprite = s1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        criarLocaisMarcados();
        criarPartes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
