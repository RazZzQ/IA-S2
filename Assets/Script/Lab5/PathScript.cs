using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathScript : MonoBehaviour
{
    // Referencia al componente NavMeshAgent
    private NavMeshAgent agent;

    // Variable pública para asignar el objetivo desde el Inspector
    public Transform targetTransform;

    // Variable pública para visualizar el camino en la escena (opcional)
    public LineRenderer pathLineRenderer;

    void Start()
    {
        // Obtén el componente NavMeshAgent en el objeto al que está asociado este script
        agent = GetComponent<NavMeshAgent>();

        // Configura el LineRenderer si se usa para visualizar el camino
        if (pathLineRenderer != null)
        {
            pathLineRenderer.positionCount = 0;
        }
    }

    // Función para calcular y mover el agente a una posición objetivo usando un NavMeshPath
    public void CalculatePath(Vector3 targetPosition)
    {
        if (agent != null)
        {
            // Crea un nuevo NavMeshPath
            NavMeshPath path = new NavMeshPath();

            // Calcula el camino desde la posición actual del agente hasta la posición objetivo
            agent.CalculatePath(targetPosition, path);

            // Mueve el agente a la primera posición del camino calculado
            if (path.corners.Length > 0)
            {
                agent.SetDestination(targetPosition);

                // (Opcional) Visualiza el camino con un LineRenderer
                if (pathLineRenderer != null)
                {
                    pathLineRenderer.positionCount = path.corners.Length;
                    pathLineRenderer.SetPositions(path.corners);
                }
            }
            else
            {
                Debug.LogWarning("El camino no es válido o está vacío.");
            }
        }
        else
        {
            Debug.LogError("NavMeshAgent no encontrado en el objeto.");
        }
    }

    // Puedes usar esta función para probar el cálculo del camino en el juego
    void Update()
    {
        // Ejemplo: Calcula el camino cuando presionas la tecla "P"
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (targetTransform != null)
            {
                CalculatePath(targetTransform.position);
            }
            else
            {
                Debug.LogError("Transform objetivo no asignado.");
            }
        }
    }
}
