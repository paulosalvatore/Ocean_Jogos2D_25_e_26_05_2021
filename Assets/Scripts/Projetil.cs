using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float velocidade = 20f;

    public float delayDestruir = 5f;

    void Start()
    {
        Destroy(gameObject, delayDestruir);
    }

    void Update()
    {
        var direcao = Vector2.up;

        transform.Translate(direcao * velocidade * Time.deltaTime);
    }
}
