using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathScript : MonoBehaviour
{
    // Referencia al componente NavMeshAgent
    private NavMeshAgent agent;

    // Variable p�blica para asignar el objetivo desde el Inspector
    public Transform targetTransform;

    // Variable p�blica para visualizar el camino en la escena (opcional)
    public LineRenderer pathLineRenderer;

    void Start()
    {
        // Obt�n el componente NavMeshAgent en el objeto al que est� asociado este script
        agent = GetComponent<NavMeshAgent>();

        // Configura el LineRenderer si se usa para visualizar el camino
        if (pathLineRenderer != null)
        {
            pathLineRenderer.positionCount = 0;
        }
    }

    // Funci�n para calcular y mover el agente a una posici�n objetivo usando un NavMeshPath
    public void CalculatePath(Vector3 targetPosition)
    {
        if (agent != null)
        {
            // Crea un nuevo NavMeshPath
            NavMeshPath path = new NavMeshPath();

            // Calcula el camino desde la posici�n actual del agente hasta la posici�n objetivo
            agent.CalculatePath(targetPosition, path);

            // Mueve el agente a la primera posici�n del camino calculado
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
                Debug.LogWarning("El camino no es v�lido o est� vac�o.");
            }
        }
        else
        {
            Debug.LogError("NavMeshAgent no encontrado en el objeto.");
        }
    }

    // Puedes usar esta funci�n para probar el c�lculo del camino en el juego
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
