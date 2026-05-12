using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecionaMonitor : MonoBehaviour
{
    //variaveis para alteração da renderização do objeto
    public GameObject textMesh;
    public MeshRenderer screenRenderer;
    public Material emissiveMaterial;
    public Material normalMaterial;

    //variaveis para resposta do clique, utiliza a classe
    //CondicaoTexto para definir a mensagem de resposta
    public CondicaoTexto resposta;
    private string mensagem;

    private bool isOn = false; //variável de estado do monitor
    private bool bloqueado = true; //variável para indicar se o computador está bloqueado
    public TMP_InputField campoSenha; // Campo de input para a senha

    private bool totalPistas = false; // Variável para verificar se o jogador coletou todas as pistas

    private void Start()
    {
        //começa a cena com o monitor desligado
        TurnOffComputer();
        campoSenha.gameObject.SetActive(false); // Esconde o campo de senha no início
    }

    // ligar ou desligar o monitor quando o jogador clicar nele
    private void OnMouseDown()
    {
        if (isOn && !bloqueado)
        {
            TurnOffComputer();
            SceneManager.LoadScene("FasePuzzleAudio");
        } else if (isOn && bloqueado)
        {
            TurnOffComputer();
        }
        else
            TurnOnComputer();
    }

    private void TurnOnComputer()
    {
        VerificaPistas();
        if (totalPistas)
        {
            BloqueioComputador();
        }
        else {
            return;
        }

        // altera a renderização do monitor para ativo
        if (screenRenderer != null && emissiveMaterial != null)
        {
            Material[] mats = screenRenderer.materials;
            mats[1] = emissiveMaterial;
            screenRenderer.materials = mats;
        }

        if (textMesh != null)
        {
            textMesh.SetActive(true);
        }

        isOn = true;
        if (totalPistas && !bloqueado)
        {
            
        }
    }

    // Método para verificar se o computador está bloqueado
    private void BloqueioComputador()
    {
        if (bloqueado)
        {
            mensagem = "O computador está bloqueado.\nInsira senha de cinco dígitos.";
            campoSenha.gameObject.SetActive(true); // Exibe o campo de senha
            // Adiciona listener para verificar a senha quando o jogador terminar de digitar
            campoSenha.onEndEdit.AddListener(VerificarSenha); 
        }
        if (resposta != null)
        {
            resposta.DefineMensagem(mensagem);
        }

    }

    private void VerificarSenha(string senha)
    {
        if (senha == "21712") // Verifica se a senha é correta
        {
            bloqueado = false;
            mensagem = "Senha correta! O computador está desbloqueado.";
            campoSenha.gameObject.SetActive(false); // Esconde o campo de senha
        }
        else
        {
            mensagem = "Senha incorreta. Tente novamente.";
        }
        if (resposta != null)
        {
            resposta.DefineMensagem(mensagem);
        }
    }

    private void VerificaPistas()
    {
        if (GerenciaJogo.instancia.pistas == 2)
        {
            totalPistas = true;
        }
        else { 
            mensagem = "O computador parece não iniciar. Talvez haja algo que você precise descobrir antes de usá-lo.";
            if (resposta != null)
            {
                resposta.DefineMensagem(mensagem);
            }
        }
    }
    private void TurnOffComputer()
    {
        mensagem = null;

        // altera a renderização do monitor para inativo
        if (screenRenderer != null && normalMaterial != null)
        {
            Material[] mats = screenRenderer.materials;
            mats[1] = normalMaterial;
            screenRenderer.materials = mats;
        }

        if (textMesh != null)
        {
            textMesh.SetActive(false);
        }

        // retira a mensagem de resposta
        if (resposta != null)
        {
            resposta.DefineMensagem(mensagem);
        }

        isOn = false;
    }
}
