using TMPro;
using UnityEngine;

public class CondicaoTexto : MonoBehaviour
{
    // variavel para referenciar o texto de resposta
    public TMP_Text resposta;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Define a mensagem de resposta e ativa o texto
    public void DefineMensagem(string mensagem)
    {
        resposta.text = mensagem;
        EstadoTexto();
    }
    private void EstadoTexto()
    {
        if (resposta.text != null)
        {
            resposta.gameObject.SetActive(true);
        }
        else
        {
            resposta.gameObject.SetActive(false);
        }
    }
}
