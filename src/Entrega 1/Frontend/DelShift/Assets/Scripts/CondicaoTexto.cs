using TMPro;
using UnityEngine;

public class CondicaoTexto : MonoBehaviour
{
    // variavel para referenciar o texto de resposta
    public TMP_Text resposta;
        
    // Define a mensagem de resposta
    public void DefineMensagem(string mensagem)
    {
        resposta.text = mensagem;
        EstadoTexto();
    }
    // Ativa ou desetiva o texto a partir de seu conteúdo
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
