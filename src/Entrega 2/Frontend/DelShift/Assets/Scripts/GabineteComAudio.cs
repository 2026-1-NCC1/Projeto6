using UnityEngine;

public class GabineteComAudio : MonoBehaviour
{
    private bool JogadorPerto = false;
    public CondicaoTexto resposta;
    private string mensagem;
    private int pistaColetada = 0;
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

    // Método de interação com objeto, verifica se pista foi coletada
    // e altera mensagem de resposta e contagem de pistas coletadas
    private void Interacao()
    {
        if (pistaColetada == 0 && resposta != null)
        {
            mensagem = "Você encontrou a amostra de áudio da voz da vítima!";
            pistaColetada++;
            resposta.DefineMensagem(mensagem);
            GerenciaJogo.instancia.ColetaPistas();
        }
        else if (pistaColetada == 1 && resposta != null)
        {
            mensagem = "Não há mais nada aqui";
            resposta.DefineMensagem(mensagem);
        }
        visto = true;
    }
}
