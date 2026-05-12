using TMPro;
using UnityEngine;

public class TextosPistas : MonoBehaviour
{
    public TMP_Text pistaBonus;
    public bool textoAtivo = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GerenciaJogo.instancia.desafiosConcluidos <= 0)
        {
            pistaBonus.gameObject.SetActive(false);
        }
        else {
            string message = "Nova pista adquirida! A análise dos arquivos de áudio revelaram um som de fundo. Segundo a Dra. Vance parece com o relógio de sala da casa dela e do marido.";
            pistaBonus.text = message;
            pistaBonus.gameObject.SetActive(true);
        }
    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && textoAtivo)
        {
            pistaBonus.gameObject.SetActive(false);
            GerenciaJogo.instancia.FimDeJogo();
        }
    }
}
