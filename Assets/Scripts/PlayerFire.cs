using UnityEngine;
using System.Collections;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] float attackSpeed;
    [SerializeField] float damage;
    [SerializeField] int bullets;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSource1;

    private float time = 0;
    public ParticleSystem muzzleFlash;

    private void Update()
    {
        time += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        if (time > attackSpeed)
        {
            Shoot();
            time = 0;
        }
    }
    private void Shoot()
    {   
        audioSource.Play();
        StartCoroutine(PlayMuzzleFlash());
        RaycastHit raycast;
        if (Physics.Raycast(transform.position, transform.forward, out raycast, Mathf.Infinity, enemyLayer))
        {
            Debug.Log(raycast.transform.name);
            EnemyHP enemyHP = raycast.transform.GetComponent<EnemyHP>();
            enemyHP.TakeDamage(damage);
        }

    }

    public void ActivateParticleSystem()
    {
        muzzleFlash.gameObject.SetActive(true);
    }

    public void DeactivateParticleSystem()
    {
        muzzleFlash.gameObject.SetActive(false);
    }

    private IEnumerator PlayMuzzleFlash()
    {
        // Включение Particle System
        ActivateParticleSystem();

        // Задержка на 0.5 секунды
        yield return new WaitForSeconds(0.2f);

        // Выключение Particle System
        DeactivateParticleSystem();
    }
}
