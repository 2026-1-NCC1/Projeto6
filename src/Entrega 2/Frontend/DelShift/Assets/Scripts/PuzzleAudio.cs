using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class PuzzleAudio : MonoBehaviour
{
    // Variavel para manipular o audio
    public AudioSource audioChantagem;
    public AudioSource audioVoz;
    private float pitchCerto;
    public Slider pitchSlider;
    public Slider volumeSlider;
    private float volumeCerto;

    // Variaveis para controle do tempo e vantagem do jogador
    public float tempoLimite = 30f;
    private float tempoRestantePuzzle;
    public TMP_Text textoTempoPuzzle;
    public GameObject textoInformativo;
    public TMP_Text tempoRestante;

    public Button botaoAvancar;
    public Button botaoPista;
    private bool ajustePitch = false;
    private bool ajusteVolume = false;

    void Start()
    {
        // Define o valor a ser encontrado no slider,
        // os limites do slider e o valor inicial do pitch do audio
        pitchCerto = Random.Range(0.5f, 1.5f);
        //Debug.Log("Valor a ser encontrado: " + pitchCerto);
        pitchSlider.minValue = Random.Range(-2.0f, pitchCerto - 0.5f);
        pitchSlider.maxValue = Random.Range(pitchCerto + 0.5f, 3f);
        volumeCerto = Random.Range(0.5f, 1.0f);
        volumeSlider.minValue = Random.Range(0.0f, 0.5f);
        volumeSlider.maxValue = Random.Range(volumeCerto + 0.5f, 2.0f);
        volumeSlider.maxValue = Random.Range(volumeCerto + 0.5f, 2.0f);
        audioChantagem.pitch = Random.Range(-1.0f, 3.0f);
        audioVoz.volume = Random.Range(0.0f, 1.0f);

        tempoRestantePuzzle = tempoLimite;
        botaoAvancar.gameObject.SetActive(false);
        botaoPista.gameObject.SetActive(false);

    }

    void Update()
    {
        tempoRestante.text = GerenciaJogo.instancia.FormataTempo();
        // Atualiza o tempo restante e exibe na tela
        if (tempoRestantePuzzle > 0)
        {
            tempoRestantePuzzle -= Time.deltaTime;
            TimeSpan tempo = TimeSpan.FromSeconds(tempoRestantePuzzle);
            textoTempoPuzzle.text = string.Format("{0:D2}:{1:D2}", tempo.Minutes, tempo.Seconds);
        }
        else
        {
            // Se o tempo acabar, o jogador é informado de atividade detectada
            tempoRestantePuzzle = 0;
            textoInformativo.SetActive(false);
            textoTempoPuzzle.text = "Atividade Detectada!\nTempo Limite da chantagem pode ser alterado.";
        }

        if (ajustePitch && ajusteVolume)
        {
            Debug.Log("Ajustes alcançados!");
            audioVoz.Stop();
            audioChantagem.Stop();
            botaoAvancar.gameObject.SetActive(true);
        }
    }

    // Recebe o valor do slider sempre que ele for alterado e ajusta o pitch do audio
    public void AjustaPitch(float valor)
    {
        audioChantagem.pitch = valor;
    }

    public void AjustaVolume(float valor)
    {
        audioChantagem.volume = valor;
    }

    // Verifica se o valor do slider está dentro da faixa correta para o puzzle
    // Método chamado quando o jogador parar de arrastar o slider e ativa o botão para prosseguir
    public void VerificaPitch()
    {
        if (pitchSlider.value < pitchCerto + 0.05f && pitchSlider.value > pitchCerto - 0.05f)
        {
            audioChantagem.pitch = 1f;
            pitchSlider.interactable = false;
            ajustePitch = true;
        }
    }

    public void VerificaVolume()
    {
        if (volumeSlider.value < volumeCerto + 0.02f && volumeSlider.value > volumeCerto - 0.02f)
        {
            audioVoz.volume = 1f;
            volumeSlider.interactable = false;
            ajusteVolume = true;
        }
    }

    //Altera cor do slider enquanto o jogador estiver arrastando,
    //indicando se o valor está acima ou abaixo do valor correto
    public void MudaCorDrag()
    {
        ColorBlock blocoCor = pitchSlider.colors;
        if (pitchSlider.value > pitchCerto)
        {
            blocoCor.pressedColor = Color.red;
        }
        else if (pitchSlider.value < pitchCerto)
        {
            blocoCor.pressedColor = Color.cyan;
        }
        pitchSlider.colors = blocoCor;
    }

    //Método para voltar cena principal
    public void VoltarCena()
    {
        SceneManager.LoadScene("CenaPrincipal");
    }

    //Método para concluir o puzzle
    public void ConcluirPuzzle()
    {
        GerenciaJogo.instancia.ConcluirDesafio(tempoLimite, tempoLimite - tempoRestantePuzzle);
        botaoPista.gameObject.SetActive(true);
        Debug.Log("Puzzle concluído! Avançando para a próxima etapa.");
    }

    public void FinalizaJogo()
    {
        GerenciaJogo.instancia.FimDeJogo();
    }

    }