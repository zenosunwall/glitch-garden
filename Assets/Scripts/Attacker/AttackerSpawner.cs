using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float spawnRateFloor = 1f;
    [SerializeField] float spawnRateCelling = 5f;
    [SerializeField] Attacker[] attackerPerfabs;

    bool spawn = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(spawnRateFloor, spawnRateCelling));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Attacker newAttacker = Instantiate(GetRandomAttacker(), transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }

    private Attacker GetRandomAttacker()
    {
        return attackerPerfabs[Random.Range(0, attackerPerfabs.Length)];
    }

    public void StopSpawning()
    {
        spawn = false;
    }
}
