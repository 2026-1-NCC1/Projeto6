using UnityEngine;

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

    private void Start()
    {
        //começa a cena com o monitor desligado
        TurnOffComputer();
    }

    // ligar ou desligar o monitor quando o jogador clicar nele
    private void OnMouseDown()
    {
        if (isOn)
            TurnOffComputer();
        else
            TurnOnComputer();
    }

    private void TurnOnComputer()
    {
        mensagem = "O computador está bloqueado";

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

        // exibe a mensagem de resposta
        if (resposta != null)
        {
            resposta.DefineMensagem(mensagem);
        }

        isOn = true;
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
