using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Test noiseEmitter; // Referencia al NoiseEmitter

    private void Start()
    {
        // Asegúrate de que el NoiseEmitter esté adjunto al mismo GameObject
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
        // Aquí podrías poner la lógica de salto (no se incluye el código de salto)
        Debug.Log("Player jumped!");

        // Emitir el ruido cuando el jugador salta
        if (noiseEmitter != null)
        {
            noiseEmitter.EmitNoise();
        }
    }
}
