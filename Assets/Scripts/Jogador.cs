using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float velocidade = 2f;

    // Start é chamado uma vez assim que o jogo inicia
    void Start()
    {

    }

    // Update é chamado o tempo todo enquanto o jogo estiver rodando
    // O número de vezes que ele é chamado depende do FPS que o jogo está rodando
    void Update()
    {
        // Pegar movimento das setas (horizontal e vertical)
        // Aplicar esse valor na posição do jogador
        // Para alterar a posição do jogador ou de qualquer outro objeto, usamos o componente Transform
        // O componente Transform pode ser acessado diretamente por QUALQUER script.

        var h = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
        var v = Input.GetAxis("Vertical") * velocidade * Time.deltaTime;

        transform.Translate(h, v, 0);
    }
}
