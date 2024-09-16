using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveSample : MonoBehaviour
{
    public Vector3 randomPosition;
    // Funci�n para obtener una posici�n aleatoria dentro del NavMesh
    public void SamplePosition(Vector3 centerPosition, float range, out Vector3 resultPosition)
    {
        // Inicializa la variable de salida
        resultPosition = Vector3.zero;

        // Define un objeto de tipo NavMeshHit para almacenar el resultado
        NavMeshHit hit;

        // Utiliza NavMesh.SamplePosition para obtener una posici�n dentro del rango especificado
        bool isValid = NavMesh.SamplePosition(centerPosition, out hit, range, NavMesh.AllAreas);

        // Si se encontr� una posici�n v�lida, asigna la posici�n al resultado
        if (isValid)
        {
            resultPosition = hit.position;
        }
        else
        {
            Debug.LogWarning("No se pudo encontrar una posici�n v�lida dentro del rango.");
        }
    }

    // Puedes usar esta funci�n para probar la muestra en el juego
    void Update()
    {
        // Ejemplo: Muestra una posici�n aleatoria cuando presionas la tecla "S"
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 center = transform.position; // Posici�n central como el de este GameObject
            float range = 10f; // Rango de b�squeda

            SamplePosition(center, range, out randomPosition);

            // Opcional: Muestra la posici�n en la consola y crea un gizmo para visualizarla
            Debug.Log("Posici�n aleatoria dentro del NavMesh: " + randomPosition);
            Debug.DrawLine(center, randomPosition, Color.red, 5f); // Dibuja una l�nea en la escena para visualizaci�n
        }
    }
}
