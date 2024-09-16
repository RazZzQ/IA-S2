using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Test noiseEmitter; // Referencia al NoiseEmitter

    private void Start()
    {
        // Aseg�rate de que el NoiseEmitter est� adjunto al mismo GameObject
        noiseEmitter = GetComponent<Test>();
    }

    void Update()
    {
        // Si el jugador presiona la barra espaciadora, salta y emite un ruido
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        // Aqu� podr�as poner la l�gica de salto (no se incluye el c�digo de salto)
        Debug.Log("Player jumped!");

        // Emitir el ruido cuando el jugador salta
        if (noiseEmitter != null)
        {
            noiseEmitter.EmitNoise();
        }
    }
}
