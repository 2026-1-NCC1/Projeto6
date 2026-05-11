using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciaJogo : MonoBehaviour
{
    public static GerenciaJogo instancia; // Instância script para acesso global

    public int pistas = 0;

    // Variaveis para controle do tempo
    public float tempoTotal = 300f;
    private float tempoRestante;
    private bool jogoAtivo = false;
    public float multiplicador = 1f; // Multiplicador a ser aplicado à contagem dependendo do desempenho do jogador
    void Awake()
    {
        // Verifica se já existe uma instância do GerenciaJogo
        if (instancia == null)
        {
            instancia = this; // Define a instância atual como a única
            DontDestroyOnLoad(gameObject); // Mantém o objeto entre cenas
        }
        else
        {
            Destroy(gameObject); // Destroi objetos duplicados
        }
    }
    void Start()
    {
        // Define tempo para contagem regressiva e ativa o jogo
        tempoRestante = tempoTotal;
        jogoAtivo = true;
    }

    void Update()
    {
        if (jogoAtivo)
        {
            AtualizaTempo();
        }
    }

    // Atualiza contagem de tempo e verifica se ele acabou
    private void AtualizaTempo()
    {
        if (tempoRestante > 0)
        {
            tempoRestante -= Time.deltaTime * multiplicador;
        }
        else
        {
            tempoRestante = 0;
            jogoAtivo = false;
            GameOver();
        }
    }

    // Método para coletar pistas, incrementa o contador de pistas
    public void ColetaPistas()
    {
        pistas++;
    }

    // Ajusta multiplicador para vantagem ou desvantagem após conlcuir um desafio
    public void ConcluirDesafio(float tLimite, float tUsado)
    {
        if (tUsado < tLimite * 0.5f)
        {
            multiplicador *= 0.9f;
        } else if (tUsado > tLimite)
        {
            multiplicador *= 1.2f;
        }

    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver"); // Carrega a cena de final de jogo
    }

    // Formata o tempo restante para exibição
    public string FormataTempo()
    {
        TimeSpan tempo = TimeSpan.FromSeconds(tempoRestante);
        return string.Format("{0:D2}:{1:D2}", tempo.Minutes, tempo.Seconds);
    }
}
