using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCcontroller : MonoBehaviour
{
    // Referencia al componente NavMeshAgent
    private NavMeshAgent agent;

    // Rango para la funci�n de vagar
    public float wanderRange = 10f;

    // Rango de evasi�n
    public float evadeRange = 5f;

    void Start()
    {
        // Obt�n el componente NavMeshAgent en el objeto al que est� asociado este script
        agent = GetComponent<NavMeshAgent>();
    }

    // Mueve el NPC hacia una posici�n objetivo
    public void MoveToPosition(Vector3 targetPosition)
    {
        if (agent != null)
        {
            agent.SetDestination(targetPosition);
            Debug.Log("dsasda");
        }
        else
        {
            Debug.LogError("NavMeshAgent no encontrado en el objeto.");
        }
    }

    // Hace que el NPC se mueva aleatoriamente dentro de un rango
    public void Wander()
    {
        if (agent != null)
        {
            Vector3 randomPosition;
            if (RandomPosition(transform.position, wanderRange, out randomPosition))
            {
                agent.SetDestination(randomPosition);
            }
            else
            {
                Debug.LogWarning("No se pudo encontrar una posici�n aleatoria dentro del rango.");
            }
        }
        else
        {
            Debug.LogError("NavMeshAgent no encontrado en el objeto.");
        }
    }

    // Hace que el NPC evite una posici�n de amenaza
    public void Evade(Vector3 threatPosition)
    {
        if (agent != null)
        {
            // Calcula una posici�n opuesta a la amenaza
            Vector3 directionAwayFromThreat = transform.position - threatPosition;
            Vector3 evadePosition = transform.position + directionAwayFromThreat.normalized * evadeRange;

            // Mueve el NPC hacia la posici�n de evasi�n
            MoveToPosition(evadePosition);
        }
        else
        {
            Debug.LogError("NavMeshAgent no encontrado en el objeto.");
        }
    }

    // Calcula una posici�n aleatoria dentro del NavMesh
    private bool RandomPosition(Vector3 centerPosition, float range, out Vector3 resultPosition)
    {
        resultPosition = Vector3.zero;

        // Define un objeto de tipo NavMeshHit para almacenar el resultado
        NavMeshHit hit;

        // Utiliza NavMesh.SamplePosition para obtener una posici�n dentro del rango especificado
        bool isValid = NavMesh.SamplePosition(centerPosition + Random.insideUnitSphere * range, out hit, range, NavMesh.AllAreas);

        // Si se encontr� una posici�n v�lida, asigna la posici�n al resultado
        if (isValid)
        {
            resultPosition = hit.position;
            return true;
        }
        else
        {
            return false;
        }
    }
}
