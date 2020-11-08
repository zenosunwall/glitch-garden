using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] float attackerTimeToLive;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Attacker attacker = otherCollider.GetComponent<Attacker>();
        if (attacker)
        {
            FindObjectOfType<BaseHealthDisplay>().DamageBase(attacker.GetBaseDamage());
            Destroy(attacker.gameObject, attackerTimeToLive);
        }
    }
}
