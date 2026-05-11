using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorCanvas : MonoBehaviour
{
    public TMP_Text tempoRestante;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Atualiza o tempo restante e exibe na tela
        tempoRestante.text = "Tempo Restante: " + GerenciaJogo.instancia.FormataTempo();
    }

    // Método para voltar ao menu inicial
    public void VoltarMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
