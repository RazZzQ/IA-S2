using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHelper : MonoBehaviour
{
    // Función para trazar una línea entre dos puntos y determinar si existe colisión
    public bool RayCast(Vector3 startPosition, Vector3 endPosition, out RaycastHit hitInfo)
    {
        // Inicializa la variable de salida
        hitInfo = new RaycastHit();

        // Trazar un rayo desde la posición de inicio hasta la posición final
        bool isHit = Physics.Linecast(startPosition, endPosition, out hitInfo);

        // Opcional: Visualizar el rayo en la escena (para depuración)
        Debug.DrawLine(startPosition, endPosition, isHit ? Color.red : Color.green, 2f);

        return isHit;
    }

    // Puedes usar esta función para probar el raycast en el juego
    void Update()
    {
        // Ejemplo: Realiza un raycast cuando presionas la tecla "R"
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 start = transform.position; // Posición de inicio (posiciona este objeto)
            Vector3 end = start + transform.forward * 10f; // Posición final (10 unidades hacia adelante desde el objeto)

            RaycastHit hitInfo;
            bool hit = RayCast(start, end, out hitInfo);

            // Muestra el resultado en la consola
            if (hit)
            {
                Debug.Log("Colisión detectada con: " + hitInfo.collider.name + " en la posición: " + hitInfo.point);
            }
            else
            {
                Debug.Log("No se detectó colisión.");
            }
        }
    }
}
