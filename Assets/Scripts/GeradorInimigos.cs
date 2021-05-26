using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    public GameObject inimigoPrefab;

    public float delayInicial = 1f;

    public float delayEntreObjetos = 2f;

    void Start()
    {
        InvokeRepeating("GerarInimigo", delayInicial, delayEntreObjetos);
    }

    void GerarInimigo()
    {
        Instantiate(inimigoPrefab, transform.position, Quaternion.identity);
    }
}
