using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 3f);

        if (transform.position.z < -10f)
        {
            gameObject.SetActive(false);
        }
    }
}
