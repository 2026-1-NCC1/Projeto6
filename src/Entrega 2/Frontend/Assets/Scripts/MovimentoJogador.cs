using UnityEngine;
using UnityEngine.Rendering;

public class MovimentoJogador : MonoBehaviour
{
    public float velocidade = 7f; // velocidade de movimento do jogador
    private Vector3 posicaoJogador;

    void Start()
    {
        // Armazena a posição inicial do jogador
        posicaoJogador = transform.position;
    }
    void Update()
    {
        // Obtém a entrada do teclado para movimentação do jogador
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Cria um vetor de movimento e aplica à posição do jogador
        Vector3 movimento = new Vector3(moveHorizontal, 0, moveVertical);
        transform.Translate(movimento * velocidade * Time.deltaTime);

        // Verifica se jogador está fora dos limites do cenário e o reposiciona
        if (transform.position.y < 1)
        {
            transform.position = posicaoJogador;
        }
    }
}
