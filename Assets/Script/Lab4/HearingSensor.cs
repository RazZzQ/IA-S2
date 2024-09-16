using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearingSensor : MonoBehaviour
{
    public float hearingRange = 10f; // Rango en el que el NPC puede o�r sonidos

    // Esta funci�n se llama cuando el NPC escucha un ruido
    public void OnNoiseHeard(Vector3 noisePosition)
    {
        float distanceToNoise = Vector3.Distance(transform.position, noisePosition);

        if (distanceToNoise <= hearingRange)
        {
            Debug.Log("NPC heard a noise at: " + noisePosition);
            ReactToNoise(noisePosition);
        }
    }

    private void ReactToNoise(Vector3 noisePosition)
    {
        Debug.Log("NPC is moving towards the noise source at: " + noisePosition);
        // Aqu� puedes programar la reacci�n del NPC al ruido
    }

    // Dibuja el rango de audici�n del NPC en la vista de escena
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green; // Define el color del Gizmo
        Gizmos.DrawWireSphere(transform.position, hearingRange); // Dibuja un c�rculo que represente el rango de audici�n
    }
}
