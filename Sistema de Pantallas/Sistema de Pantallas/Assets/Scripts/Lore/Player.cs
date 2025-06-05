using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // izquierda-derecha
        float moveZ = Input.GetAxis("Vertical");   // adelante-atrás

        Vector3 move = new Vector3(moveX, 0, moveZ);
        transform.Translate(move * 5f * Time.deltaTime);
    }
}
