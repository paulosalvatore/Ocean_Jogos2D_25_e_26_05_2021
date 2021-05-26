using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float velocidade = 2f;

    public GameObject projetilPrefab;

    // Start é chamado uma vez assim que o jogo inicia
    void Start()
    {

    }

    // Update é chamado o tempo todo enquanto o jogo estiver rodando
    // O número de vezes que ele é chamado depende do FPS que o jogo está rodando
    void Update()
    {
        Movimentar();

        Atirar();
    }

    private void Atirar()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // print("Atirar!!!");

            var projetilClone = Instantiate(projetilPrefab);

            projetilClone.transform.position = transform.position;

            var mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z;

            var worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            var direcao = (worldMousePosition - transform.position).normalized;

            projetilClone.transform.up = direcao;
        }
    }

    private void Movimentar()
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
