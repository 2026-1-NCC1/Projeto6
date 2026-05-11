using UnityEngine;

public class GabineteComGravacao : MonoBehaviour
{
    private bool JogadorPerto = false;
    public CondicaoTexto resposta;
    private string mensagem;
    private int pistaColetada = 0;

    void Update()
    {
        // Verifica se o jogador está perto e clicou para interagir com o objeto
        if (JogadorPerto && Input.GetMouseButtonDown(0))
        {
            Interacao();
        }
        else if (Input.GetMouseButtonDown(0) && pistaColetada == 1)
        {
            mensagem = null;
            resposta.DefineMensagem(mensagem);
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

    // Método de interação com objeto, verifica se pista foi coletada
    // e altera mensagem de resposta e contagem de pistas coletadas
    private void Interacao()
    {
        if (pistaColetada == 0 && resposta != null)
        {
            mensagem = "Você encontrou a cópia da gravação da chantagem!";
            pistaColetada++;
            resposta.DefineMensagem(mensagem);
            GerenciaJogo.instancia.ColetaPistas();
        }
        else if (pistaColetada == 1 && resposta != null)
        {
            mensagem = "Não há mais nada aqui";
            resposta.DefineMensagem(mensagem);
        }
    }
}
