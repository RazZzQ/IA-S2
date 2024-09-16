using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHelper : MonoBehaviour
{
    // Funci�n para trazar una l�nea entre dos puntos y determinar si existe colisi�n
    public bool RayCast(Vector3 startPosition, Vector3 endPosition, out RaycastHit hitInfo)
    {
        // Inicializa la variable de salida
        hitInfo = new RaycastHit();

        // Trazar un rayo desde la posici�n de inicio hasta la posici�n final
        bool isHit = Physics.Linecast(startPosition, endPosition, out hitInfo);

        // Opcional: Visualizar el rayo en la escena (para depuraci�n)
        Debug.DrawLine(startPosition, endPosition, isHit ? Color.red : Color.green, 2f);

        return isHit;
    }

    // Puedes usar esta funci�n para probar el raycast en el juego
    void Update()
    {
        // Ejemplo: Realiza un raycast cuando presionas la tecla "R"
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 start = transform.position; // Posici�n de inicio (posiciona este objeto)
            Vector3 end = start + transform.forward * 10f; // Posici�n final (10 unidades hacia adelante desde el objeto)

            RaycastHit hitInfo;
            bool hit = RayCast(start, end, out hitInfo);

            // Muestra el resultado en la consola
            if (hit)
            {
                Debug.Log("Colisi�n detectada con: " + hitInfo.collider.name + " en la posici�n: " + hitInfo.point);
            }
            else
            {
                Debug.Log("No se detect� colisi�n.");
            }
        }
    }
}
