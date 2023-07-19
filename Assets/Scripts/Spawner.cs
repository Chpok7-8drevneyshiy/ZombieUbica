using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Zombie;
    [SerializeField] float delay;

    private void Start()
    {
       StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        Debug.Log("Spawn");
        Instantiate(Zombie, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(delay);
        StartCoroutine(Spawn());
    }
}
