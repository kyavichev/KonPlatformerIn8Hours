using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttacker : MonoBehaviour
{
    public enum AttackType
    {
        Default,
        Fire,
        Ice,
    }

    public GameObject projectilePrefab;
    public GameObject fireProjectilePrefab;
    public GameObject iceProjectilePrefab;

    public GameObject spawnPoint;

    public float cooldown = 0.5f;
    private float cooldownTimer = 0;

    public ViewOrientation viewOrientation;

    public int specialAmmoCount = 0;
    public AttackType attackType = AttackType.Default;


    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        cooldownTimer = Mathf.Max(cooldownTimer, 0);
    }


    public void Fire()
    {
        if (cooldownTimer > 0)
        {
            Debug.Log("cooling down");
        }
        else
        {
            // Create a new projectile from the prefab
            GameObject projectilePrefabToUse = projectilePrefab;
            int numProjectilesToSpawn = 1;

            if (specialAmmoCount > 0)
            {
                switch(attackType)
                {
                    case AttackType.Default:
                        projectilePrefabToUse = projectilePrefab;
                        break;

                    case AttackType.Fire:
                        projectilePrefabToUse = fireProjectilePrefab;
                        numProjectilesToSpawn = 3; // Random.Range(1, 5);
                        break;

                    case AttackType.Ice:
                        projectilePrefabToUse = iceProjectilePrefab;
                        break;
                }

                specialAmmoCount--;
            }

            for (int i = 0; i < numProjectilesToSpawn; i++)
            {
                GameObject newProjectile = Instantiate(projectilePrefabToUse);

                // This variable holds the initial position for the projectile
                Vector3 spawnPosition = spawnPoint.transform.position;
                if (viewOrientation != null && viewOrientation.IsFlipped())
                {
                    Vector3 localSpawnPointPosition = spawnPoint.transform.localPosition;
                    localSpawnPointPosition.x *= -1f;

                    spawnPosition = transform.TransformPoint(localSpawnPointPosition);
                }
                newProjectile.transform.position = spawnPosition;

                float yNoise = Random.Range(-0.1f, 0.1f);

                // Set direction on the projectile
                VelocityApplier velocityApplier = newProjectile.GetComponent<VelocityApplier>();
                if (velocityApplier)
                {
                    if (viewOrientation != null)
                    {
                        if (viewOrientation.IsFlipped())
                        {
                            velocityApplier.direction = new Vector2(-1, yNoise);
                        }
                        else
                        {
                            velocityApplier.direction = new Vector2(1, yNoise);
                        }
                    }
                    else
                    {
                        velocityApplier.direction = new Vector2(1, yNoise);
                    }
                }
            }

            cooldownTimer = cooldown;
        }
    }


    public void GiveAmmo(int ammoCount, AttackType ammoType)
    {
        specialAmmoCount = ammoCount;
        attackType = ammoType;
    }
}
