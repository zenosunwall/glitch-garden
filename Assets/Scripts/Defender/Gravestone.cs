using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    Attacker currentAttacker;

    private void Update()
    {
        if (!currentAttacker)
        {
            GetComponent<Animator>().SetBool("isDefending", false);
        }
    }

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        Attacker attacker = otherCollider.GetComponent<Attacker>();
        if (attacker && !attacker.GetComponent<Fox>())
        {
            GetComponent<Animator>().SetBool("isDefending", true);
            currentAttacker = attacker;
        }
    }
}
