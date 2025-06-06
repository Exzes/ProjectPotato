using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDoDamage
{
    private int damage = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoDamage()
    {
        HealthManager.Instance.TakeDamage(damage);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DoDamage();
            Debug.Log("Dañó");
        }
    }
}
