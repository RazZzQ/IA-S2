using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCbehavior : MonoBehaviour
{
    public NPCcontroller npcController; // Arrastra y suelta el GameObject con NPCController aquí
    public Transform threatTransform;   // Asigna el objeto que representa la amenaza
    public MoveSample moveSample;
    void Start()
    {
    }

    void Update()
    {
        if (npcController != null)
        {
            // Hace que el NPC vagar cuando presionas la tecla "W"
            if (Input.GetKeyDown(KeyCode.W))
            {
                npcController.Wander();
            }

            // Hace que el NPC evada una amenaza cuando presionas la tecla "E"
            if (Input.GetKeyDown(KeyCode.Q) && threatTransform != null)
            {
                npcController.Evade(threatTransform.position);
            }
            if (Input.GetKeyDown(KeyCode.D) && moveSample.randomPosition != Vector3.zero)
            {
                npcController.MoveToPosition(moveSample.randomPosition);
                Debug.Log("mmm");
            }
        }
    }
}
