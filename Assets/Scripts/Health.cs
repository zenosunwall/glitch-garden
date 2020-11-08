using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVisualEffect;
    [SerializeField] GameObject position;

    GameObject deathEffectParent;
    const string DEATH_EFFECT_PARENT = "DeathEffects";

    private void Start()
    {
        deathEffectParent = GameObject.Find(DEATH_EFFECT_PARENT);
        if (!deathEffectParent)
        {
            deathEffectParent = new GameObject(DEATH_EFFECT_PARENT);
        }
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0) 
        {
            DeathEffect();
            Destroy(gameObject);
        }
    }

    public void DeathEffect()
    {
        if (deathVisualEffect)
        {
            GameObject deathEffect = Instantiate(deathVisualEffect, position.transform.position, position.transform.rotation);
            deathEffect.transform.parent = deathEffectParent.transform;
            Destroy(deathEffect, 2f);
        }
    }
}
