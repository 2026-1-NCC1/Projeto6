using UnityEngine;
using UnityEngine.SceneManagement;

public class FuncoesMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Inicia o jogo carregando a cena principal
    public void IniciarJogo()
    {
        SceneManager.LoadScene("CenaPrincipal");
    }

    public void SairJogo()
    {
        Debug.Log("Fechando o Jogo");
    }

}
