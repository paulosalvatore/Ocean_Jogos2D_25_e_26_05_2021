using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float velocidade = 20f;

    void Update()
    {
        var direcao = Vector2.up;

        transform.Translate(direcao * velocidade * Time.deltaTime);
    }
}
