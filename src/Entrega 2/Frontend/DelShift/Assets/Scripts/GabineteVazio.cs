using UnityEngine;

public class GabineteVazio : MonoBehaviour
{
    private bool JogadorPerto = false;
    public CondicaoTexto resposta;
    private string mensagem;
    private bool visto = false;

    void Update()
    {
        // Verifica se o jogador está perto e clicou para interagir com o objeto
        if (JogadorPerto && Input.GetMouseButtonDown(0))
        {
            Interacao();
        }
        else if (!JogadorPerto && visto)
        {
            mensagem = null;
            resposta.DefineMensagem(mensagem);
            visto = false;
        }

    }

    // Verifica se o jogador está perto do objeto para ativar opção de clique
    private void OnCollisionEnter(Collision batida)
    {
        if (batida.gameObject.name == "Jogador")
        {
            JogadorPerto = true;
        }
    }

    // Verifica se o jogador saiu do objeto para desativar opção de clique
    private void OnCollisionExit(Collision batida)
    {
        if (batida.gameObject.name == "Jogador")
        {
            JogadorPerto = false;
        }
    }

    // Método de interação com objeto, altera mensagem de resposta
    private void Interacao()
    {
        if (!visto && resposta != null)
        {
            mensagem = "Não há nada aqui.";
            resposta.DefineMensagem(mensagem);
            visto = true;
        }
    }
}
