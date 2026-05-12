using System;
using TMPro;
using UnityEngine;
using System.IO;

public class GerenciaDados : MonoBehaviour
{
    // Variaveis para exibição de dados finais
    public TMP_Text tempo;
    public TMP_Text pistas;
    public TMP_Text desafios;
    private string caminhoArquivoDadosLocal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Define caminho para criar aquivo local com dados do resultado
        caminhoArquivoDadosLocal = Application.persistentDataPath + "/HistoricoDelShift.txt";
        Debug.Log("Caminho do arquivo" + caminhoArquivoDadosLocal);

        string mTempo = GerenciaJogo.instancia.FormataTempo() + " / " + FormataDado(GerenciaJogo.instancia.tempoTotal);
        string mPistas = GerenciaJogo.instancia.pistas + " / " + GerenciaJogo.instancia.totalPistas;
        string mDesafios = GerenciaJogo.instancia.desafiosConcluidos + " / " + GerenciaJogo.instancia.totalDesafios;
        tempo.text = mTempo;
        pistas.text = mPistas;
        desafios.text = mDesafios;
        RegistraDado("Tempo Restante - " + mTempo);
        RegistraDado("Pistas Coletadas - " + mPistas);
        RegistraDado("Desafios Concluídos - " + mDesafios);
    }

    //Grava dados no arquivo determinado pelo caminho
    public void RegistraDado(string dado)
    {
        string dadoFormatado = $"[{DateTime.Now}] - {dado}{Environment.NewLine}";
        File.AppendAllText(caminhoArquivoDadosLocal, dadoFormatado);
    }

    private string FormataDado(float tempo)
    {
        TimeSpan t = TimeSpan.FromSeconds(tempo);
        return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
    }

}
