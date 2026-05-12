using UnityEngine;
using UnityEngine.SceneManagement;

public class FuncoesMenu : MonoBehaviour
{
    // Inicia o jogo carregando a cena principal
    public void IniciarJogo()
    {
        SceneManager.LoadScene("Introducao");
    }

    public void SairJogo()
    {
        Debug.Log("Fechando o Jogo...");
        Application.Quit();       
    }

    public void IniciaCenaPrincipal()
    {
        SceneManager.LoadScene("CenaPrincipal");
    }

}
