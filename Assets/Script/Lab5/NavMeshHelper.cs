using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshHelper : MonoBehaviour
{
    // Funci�n para encontrar el punto m�s cercano en el borde del NavMesh
    public void FindClosestEdge(Vector3 position, out Vector3 closestPoint)
    {
        closestPoint = Vector3.zero; // Inicializa la variable de salida

        // Define un objeto de tipo NavMeshHit para almacenar el resultado
        NavMeshHit hit;

        // Utiliza NavMesh.FindClosestEdge para encontrar el borde m�s cercano
        bool found = NavMesh.FindClosestEdge(position, out hit, NavMesh.AllAreas);

        // Si se encontr� un borde, asigna la posici�n al resultado
        if (found)
        {
            closestPoint = hit.position;
        }
        else
        {
            Debug.LogWarning("No se pudo encontrar un borde cercano.");
        }
    }

    // Puedes usar esta funci�n para probar la b�squeda del borde m�s cercano en el juego
    void Update()
    {
        // Ejemplo: Encuentra el borde m�s cercano cuando presionas la tecla "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 position = transform.position; // Posici�n de este GameObject
            Vector3 closestEdge;

            FindClosestEdge(position, out closestEdge);

            // Opcional: Muestra la posici�n en la consola y crea un gizmo para visualizarla
            Debug.Log("Punto m�s cercano en el borde del NavMesh: " + closestEdge);
            Debug.DrawLine(position, closestEdge, Color.blue, 5f); // Dibuja una l�nea en la escena para visualizaci�n
        }
    }
}
