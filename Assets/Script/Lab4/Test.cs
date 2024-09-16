using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float noiseRadius = 5f; // El rango del ruido que emite este objeto
    public LayerMask npcLayer; // Capa que contiene a los NPCs que deben escuchar el ruido

    // Función que emite un ruido
    public void EmitNoise()
    {
        // Detecta todos los NPCs dentro del radio de ruido
        Collider[] npcsInRange = Physics.OverlapSphere(transform.position, noiseRadius, npcLayer);

        // Notifica a cada NPC que ha detectado el ruido
        for (int i = 0; i < npcsInRange.Length; i++)
        {
            HearingSensor npc = npcsInRange[i].GetComponent<HearingSensor>();
            if (npc != null)
            {
                npc.OnNoiseHeard(transform.position); // Notifica al NPC de la posición del ruido
            }
        }

        Debug.Log("Noise emitted by: " + gameObject.name);
    }
}
