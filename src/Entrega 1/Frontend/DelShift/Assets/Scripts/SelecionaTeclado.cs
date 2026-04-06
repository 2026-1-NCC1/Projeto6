using UnityEngine;

public class SelecionaTeclado : MonoBehaviour
{
    public CondicaoTexto resposta;
    private string mensagem;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        mensagem = "Hm, o teclado parece não estar conectado";
        Debug.Log(mensagem);

        if (resposta != null)
        {
            resposta.DefineMensagem(mensagem);
        }
    }
}
