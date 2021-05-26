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

            // Clonamos o Prefab e adicionamos esse clone na cena
            var projetilClone = Instantiate(projetilPrefab);

            // Aplicamos a mesma posição do jogador para o clone do projétil
            projetilClone.transform.position = transform.position;

            // Obtemos a posição atual do mouse (o valor atualmente está em pixels, de acordo com o tamanho da tela)
            var mousePosition = Input.mousePosition;
            // Como a MainCamera está no Z -10 (negativo), precisamos falar que o mouse está em Z 10 (positivo)
            // Isso fará com que a MainCamera consiga converter os valores do mouse para a posição Z 0 (10 - 10 = 0)
            mousePosition.z = -Camera.main.transform.position.z;

            // Convertemos a posição do mouse (relativo a tela) para uma posição no mundo (relativo a cena)
            var worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            // Como essa posição do mouse convertida para o mundo é o nosso destino, subtraímos da posição atual
            // Essa subtração resulta em um Vector3 com direção e magnitude.
            // Eliminamos a magnitude através do 'normalized'.
            var direcao = (worldMousePosition - transform.position).normalized;

            // Agora, com a direção calculada, falamos que o clone do projetil irá sempre apontar para essa direção
            // Como estamos em um jogo 2D, alteramos o valor de 'transform.up', pois 'up' representa a frente desse objeto.
            // Transform.up está relacionado ao eixo Y.
            // Em um jogo 3D, a frente do objeto é representada por 'transform.forward', que está relacionado ao eixo Z.
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
