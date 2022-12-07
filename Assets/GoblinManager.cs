using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinManager : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private GameObject goblinPrefab;
    [SerializeField] private GameObject kitty;
    private static List<GameObject> goblins = new List<GameObject>();

    public float CooldownSpawn = 1.2f;
    private bool flagSpawn = true;

    private void Update()
    {
        var randomPosition = Random.Range(0, spawnPoints.Count);
        if (kitty.gameObject.active && goblins.Count < 5)
        {
            if (flagSpawn)
            {
                var goblin = Instantiate(goblinPrefab, spawnPoints[randomPosition].position, Quaternion.identity);
                goblins.Add(goblin);
                StartCoroutine(Fade());
            }
        }  
    }

    IEnumerator Fade()
    {
        flagSpawn = false;
        yield return new WaitForSeconds(CooldownSpawn);
        flagSpawn = true;
    }

    public static void RemoveGoblin(GameObject goblin)
    {
        goblins.Remove(goblin);
    }
}
