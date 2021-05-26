using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float velocidade = 6f;

    GameObject jogador;

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        var direcao = (jogador.transform.position - transform.position).normalized;

        transform.Translate(direcao * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projétil"))
        {
            Destroy(gameObject);

            Destroy(other.gameObject);
        }
    }
}
