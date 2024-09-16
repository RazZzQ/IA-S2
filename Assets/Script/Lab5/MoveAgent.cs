using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAgent : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform targetTransform;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToTargetPosition()
    {
        if (agent != null && targetTransform != null)
        {
            // Establece la posición objetivo del agente
            agent.SetDestination(targetTransform.position);
        }
        else
        {
            if (agent == null)
                Debug.LogError("NavMeshAgent no encontrado en el objeto.");

            if (targetTransform == null)
                Debug.LogError("Transform objetivo no asignado.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) {
            MoveToTargetPosition();
        }

    }
}
