using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveSample : MonoBehaviour
{
    public Vector3 randomPosition;
    // Función para obtener una posición aleatoria dentro del NavMesh
    public void SamplePosition(Vector3 centerPosition, float range, out Vector3 resultPosition)
    {
        // Inicializa la variable de salida
        resultPosition = Vector3.zero;

        // Define un objeto de tipo NavMeshHit para almacenar el resultado
        NavMeshHit hit;

        // Utiliza NavMesh.SamplePosition para obtener una posición dentro del rango especificado
        bool isValid = NavMesh.SamplePosition(centerPosition, out hit, range, NavMesh.AllAreas);

        // Si se encontró una posición válida, asigna la posición al resultado
        if (isValid)
        {
            resultPosition = hit.position;
        }
        else
        {
            Debug.LogWarning("No se pudo encontrar una posición válida dentro del rango.");
        }
    }

    // Puedes usar esta función para probar la muestra en el juego
    void Update()
    {
        // Ejemplo: Muestra una posición aleatoria cuando presionas la tecla "S"
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 center = transform.position; // Posición central como el de este GameObject
            float range = 10f; // Rango de búsqueda

            SamplePosition(center, range, out randomPosition);

            // Opcional: Muestra la posición en la consola y crea un gizmo para visualizarla
            Debug.Log("Posición aleatoria dentro del NavMesh: " + randomPosition);
            Debug.DrawLine(center, randomPosition, Color.red, 5f); // Dibuja una línea en la escena para visualización
        }
    }
}
