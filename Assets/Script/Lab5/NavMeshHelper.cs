using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshHelper : MonoBehaviour
{
    // Función para encontrar el punto más cercano en el borde del NavMesh
    public void FindClosestEdge(Vector3 position, out Vector3 closestPoint)
    {
        closestPoint = Vector3.zero; // Inicializa la variable de salida

        // Define un objeto de tipo NavMeshHit para almacenar el resultado
        NavMeshHit hit;

        // Utiliza NavMesh.FindClosestEdge para encontrar el borde más cercano
        bool found = NavMesh.FindClosestEdge(position, out hit, NavMesh.AllAreas);

        // Si se encontró un borde, asigna la posición al resultado
        if (found)
        {
            closestPoint = hit.position;
        }
        else
        {
            Debug.LogWarning("No se pudo encontrar un borde cercano.");
        }
    }

    // Puedes usar esta función para probar la búsqueda del borde más cercano en el juego
    void Update()
    {
        // Ejemplo: Encuentra el borde más cercano cuando presionas la tecla "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 position = transform.position; // Posición de este GameObject
            Vector3 closestEdge;

            FindClosestEdge(position, out closestEdge);

            // Opcional: Muestra la posición en la consola y crea un gizmo para visualizarla
            Debug.Log("Punto más cercano en el borde del NavMesh: " + closestEdge);
            Debug.DrawLine(position, closestEdge, Color.blue, 5f); // Dibuja una línea en la escena para visualización
        }
    }
}
