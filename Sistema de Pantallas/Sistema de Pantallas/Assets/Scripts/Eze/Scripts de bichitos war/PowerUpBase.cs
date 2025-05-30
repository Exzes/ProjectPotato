using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour //Strategy
{
    [SerializeField] protected float duration = 3f;
    protected float timer;
    protected GameObject target;
    protected bool isEffectApplied = false;

    public float GetDuration() => duration;

    public void Initialize(float duration, GameObject target)
    {
        this.duration = duration;
        this.target = target;
        StartCoroutine(EffectDuration());
    }

    protected virtual IEnumerator EffectDuration() //corrutina
    {
        if(!isEffectApplied)
        {
            ApplyEffect(target);
            isEffectApplied = true;
        }
        while (timer < duration)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            yield return null;
        }
        RemoveEffect(target);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PowerUpBase powerUp = GetComponent<PowerUpBase>();
            var onActiveEffect = collision.gameObject.GetComponentInChildren(GetType()) as PowerUpBase;
            if (onActiveEffect != null)
            {
                onActiveEffect.RestoreDuration();

            }
            else
            {
                GameObject handler = new GameObject("PowerUpEffect" + GetType().Name);
                handler.transform.SetParent(collision.transform);
                var effect = handler.AddComponent(GetType()) as PowerUpBase;
                effect.Initialize(powerUp.GetDuration(), collision.gameObject);
                Debug.Log("Paso de largo");
                
            }
            Destroy(gameObject);
        }
        
    }
    public virtual void RestoreDuration()
    {
        timer = Time.deltaTime;
        Debug.Log("Duracion extendida: " + duration);
    }

    protected abstract void ApplyEffect(GameObject target);
    protected abstract void RemoveEffect(GameObject target);
}
