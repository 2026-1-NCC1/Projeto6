using UnityEngine;

public class SelecionaMonitor : MonoBehaviour
{
    //variáveis para alteração da renderização do objeto
    public GameObject textMesh;
    public MeshRenderer screenRenderer;
    public Material emissiveMaterial;
    public Material normalMaterial;

    private bool isOn = false;

    private void Start()
    {
        //começa a cena com o monitor desligado
        TurnOffComputer();
    }

    //ligar ou desligar o monitor quando o jogador clicar nele
    private void OnMouseDown()
    {
        if (isOn)
            TurnOffComputer();
        else
            TurnOnComputer();
    }

    private void TurnOnComputer()
    {
        // altera o a renderização do monitor para ativo
        if (screenRenderer != null && emissiveMaterial != null)
        {
            Material[] mats = screenRenderer.materials;
            mats[1] = emissiveMaterial;
            screenRenderer.materials = mats;
        }

        if (textMesh != null)
            textMesh.SetActive(true);

        isOn = true;
    }

    private void TurnOffComputer()
    {
        // altera a renderização do monitor para inativo
        if (screenRenderer != null && normalMaterial != null)
        {
            Material[] mats = screenRenderer.materials;
            mats[1] = normalMaterial;
            screenRenderer.materials = mats;
        }

        if (textMesh != null)
            textMesh.SetActive(false);

        isOn = false;
    }
}
