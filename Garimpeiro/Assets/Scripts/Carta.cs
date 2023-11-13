using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Sprite sprite; // sprite para configurar as dimensões de uma carta
    public string naipe; // Naipe da Carta (C - copas, P - paus, O - ouros, E - Espadas)
    public string nome; // nome da carta 
    public int valor; // Valor de 1 a 13 (ou 14 se houver coringa)
    public GameObject back = null; // GameObject da traseira da carta
    SpriteRenderer _tSR = null;
    public SpriteRenderer[] spriteRenderers;
    public bool cartaGold = false;

    public bool faceUp { // Dupla função get e set, usaremos na sequência
        get { return(!back.activeSelf); }
        set { back.SetActive(!value); }
    }

    // Chamamos para verificar clique no GameObject
    virtual public void OnMouseDown() {
        print(valor + naipe);
        // _tSR = GetComponent<SpriteRenderer>();
        // if (_tSR.sortingOrder == 3) {
        //     _tSR.sortingOrder = 1; // Se virada, mostra-a (faceUp)
        // }
        // else {
        //     Destroy(gameObject); // se já mostrada, destroi-a
        // } 
    }

    void Start() {
        SetSortOrder(1);
    }

    public void PopulateSpriteRenderers() {
        if (spriteRenderers == null || spriteRenderers.Length == 0) {
            spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        }
    }

    public void SetSortingLayerName(string tSLN) {
        PopulateSpriteRenderers();
        foreach (SpriteRenderer tSR in spriteRenderers) {
            tSR.sortingLayerName = tSLN;
        }
    }

    public void SetSortOrder(int sOrd) {
        PopulateSpriteRenderers();
        foreach (SpriteRenderer tSR in spriteRenderers) {
            switch (tSR.gameObject.name) {
                case "back":
                    tSR.sortingOrder = sOrd + 1;
                    break;
                case "face":
                default:
                    tSR.sortingOrder = sOrd;
                    break;
            }
        }
    }
}
