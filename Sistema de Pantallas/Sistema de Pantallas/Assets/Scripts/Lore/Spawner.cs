using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnInterval = 2f;    //intervalo entre spawns cada 2 segundos
    private float timer;                //cronómetro interno 

    void Update() 
    {
        timer += Time.deltaTime;        //va sumando timer hasta que pasa el spawnInterval
        if (timer >= spawnInterval)
        {
            timer = 0f; //resetea el timer
            Spawn();    //llama a la función Spawn() 
        }
    }

    void Spawn() //función de spawneo
    {
        Vector3 posFruta = new Vector3(Random.Range(-4f, 4f), 0.5f, 10f);
        ObjectPool.Instance.SpawnFromPool("Fruta", posFruta, Quaternion.identity);

        Vector3 posEnemigo = new Vector3(Random.Range(-4f, 4f), 0.5f, 12f);
        ObjectPool.Instance.SpawnFromPool("Enemigo", posEnemigo, Quaternion.identity);
    }
}
