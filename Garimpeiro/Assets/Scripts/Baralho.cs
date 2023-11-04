using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baralho : MonoBehaviour
{
    public bool startFaceUp = true; // Inicialização das cartas abertas
    public GameObject prefabCarta; // Deverá associar aqui o prefab configurado para a Face da carta
    public GameObject prefabSprite; // Associar aqui o prefab configurado para a traseira da carta

[Header("Set Dynamically")]

    public List<string> nomesCartas; // naipes das cartas (ou tipos delas)
    public List<Carta> cartasBaralho; // conjunto de todo baralho
    public Transform pivoBaralho; // posição pivo para posicionamento
    private Sprite _tSp = null;
    private GameObject _tGO = null;
    private SpriteRenderer _tSR = null;

    void Start() {
        IniciaBaralho();
        Embaralha(ref cartasBaralho);
    }

    /* Método para configurar um conjunto completo de Baralho */
    public void IniciaBaralho() {
        GameObject centro = GameObject.Find("centroDaTela");
        pivoBaralho = centro.transform;
        bool mostra = startFaceUp;
        DescartaBaralho(mostra);
    }

    /* Método que descarta todas as cartas do Baralho, mostrando-as ou não */
    public void DescartaBaralho(bool flagMostra) {
        nomesCartas = new List<string>();
        string[] letras = new string[] {"C", "O", "E", "P"}; // Iniciais dos naipes
        foreach (string s in letras) {
            for (int i = 0; i < 13; i++) {
                nomesCartas.Add(s+(i + 1));
            }
        }
        cartasBaralho = new List<Carta>(); // todas as cartas do baralho
        for (int i = 0; i < nomesCartas.Count; i++) {
            cartasBaralho.Add(MakeCarta(flagMostra, i));
        }
    }

    /* Método que cria cada uma das cartas, e a mostra ou não */
    private Carta MakeCarta(bool faceUp, int cNum) {
        _tGO = Instantiate(prefabCarta) as GameObject; // Cria um novo GameObject Carta
        _tGO.transform.parent = pivoBaralho; // Configura o transform.parent para o pivo da nova Carta
        _tSR = _tGO.GetComponent<SpriteRenderer>(); // pega o componente de renderização de Sprite
        // _tGO.transform.localPosition = new Vector3( cNum%13 *6 - 35, cNum/13* 8 - 10, 0); // Acerta a posição de exibição
        _tGO.transform.localPosition = new Vector3(20, 5, 0);
        Carta _carta = _tGO.GetComponent<Carta>(); // pega o componente Carta
        if (nomesCartas[cNum].StartsWith("C")) _carta.naipe = "_of_hearts"; // naipes das cartas, segundo os arquivos de sprites
        else if (nomesCartas[cNum].StartsWith("O")) _carta.naipe = "_of_diamonds";
        else if (nomesCartas[cNum].StartsWith("E")) _carta.naipe = "_of_spades";
        else if (nomesCartas[cNum].StartsWith("P")) _carta.naipe = "_of_clubs";
        _carta.valor = int.Parse(nomesCartas[cNum].Substring(1)); // valor (número) da carta
        string nomeDaCarta = "";
        string numeroCarta = "";
        if (_carta.valor == 1) numeroCarta = "ace"; // cartas não numéricas
        else if (_carta.valor == 11) numeroCarta = "jack";
        else if (_carta.valor == 12) numeroCarta = "queen";
        else if (_carta.valor == 13) numeroCarta = "king";
        else numeroCarta = "" + _carta.valor;
        nomeDaCarta = numeroCarta + _carta.naipe; // nome do arquivo da carta
        _carta.nome = "face";
        _tSp = (Sprite)(Resources.Load<Sprite>(nomeDaCarta)); // lê a carta dos arquivos
        Sprite s1back = (Sprite)(Resources.Load<Sprite>("Card_Back_1")); // lê a carta dos arquivos
        _tSR.sprite = _tSp; // Add Carta com a Sprite lida
        _tSR.sortingOrder = 2; // quanto maior for a sortingOrder, mais próximo a câmera é a renderização
        _tGO = Instantiate(prefabSprite) as GameObject; // Add Back ( traseira da carta)
        _tSR = _tGO.GetComponent<SpriteRenderer>();
        _tSR.sprite = s1back;
        _tGO.transform.SetParent(_carta.transform); 
        _tGO.transform.localPosition = Vector3.zero;
        if (faceUp) _tSR.sortingOrder = 1; // A parte de trás fica com sortingOrder menor que a face da carta (FaceUp)
        else _tSR.sortingOrder = 3; // ou maior que a face, para escondê-la
        _carta.faceUp = faceUp;
        _carta.back = _tGO;
        _carta.nome = "back";
        return _carta;
    }

    static public void Embaralha(ref List<Carta> oCartas) {
        List<Carta> tCartas = new List<Carta>();
        int ndx;
        tCartas = new List<Carta>();
        while (oCartas.Count > 0) {
            ndx = Random.Range(0, oCartas.Count);
            tCartas.Add(oCartas[ndx]);
            oCartas.RemoveAt(ndx);
        }
        oCartas = tCartas;
    }
}
