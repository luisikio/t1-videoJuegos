using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jugador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = jugador.transform.position + new Vector3(-3,1,-10);
    }
}
