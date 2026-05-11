using UnityEngine;

public class SelecionaTeclado : MonoBehaviour
{
    // variaveis para resposta do clique, utiliza a classe
    // CondicaoTexto para definir mensagem
    public CondicaoTexto resposta;
    private string mensagem;

    // traz feedback na tela, exibibindo texto quando o jogador clicar no teclado
    private void OnMouseDown()
    {
        mensagem = "Hm, o teclado parece não estar conectado";
        //Debug.Log(mensagem);

        if (resposta != null)
        {
            resposta.DefineMensagem(mensagem);
        }
    }
}
