using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorDeCenas : MonoBehaviour
{
    public void CarregarCenaBaralho()
    {
        SceneManager.LoadScene("Baralho");
    }

    public void CarregarCenaPontuacao()
    {
        SceneManager.LoadScene("Pontuacao");
    }

    public void CarregarCenaTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void CarregarCenaCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    
    public void CarregarCenaInicial() {
        SceneManager.LoadScene("Inicio");
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}
