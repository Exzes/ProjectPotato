using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;



public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    private float lastDamageTime;
    private float damageCooldown = 1f;
    public event Action<int> OnHealthChanged;
    public static HealthManager Instance { get; private set; } //Para instanciar el manager

    private void Awake()
    {
        if (Instance != null && Instance != this) //Si la instancia no esta nula (existe)
        {
            Destroy(gameObject); //chau
        }
        else
        {
            Instance = this; //si no si lo instanciamos.
        }
    }

    void Start()
    {
        currentHealth = maxHealth; //seteamos la vida
        OnHealthChanged?.Invoke(currentHealth); // Primer notificación
        lastDamageTime = Time.time; //tomamos un timestamp base
    }
    public void TakeDamage(int amount)
    {
        float cooldown = lastDamageTime + damageCooldown; //calculo para el delay
        if (Time.time >= cooldown) //delay para el daño
        {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); //limites
        OnHealthChanged?.Invoke(currentHealth); //notificalo 
        lastDamageTime = Time.time;
        }
        if (currentHealth <= 0) 
        {
            Die();
        }

    }

    public int GetHealth() => currentHealth; //usa getters lucas no seas idiota

    public void Die()
    {
        SceneManager.LoadScene("PantallaDerrota"); //pantalla de derrota
    }
}
