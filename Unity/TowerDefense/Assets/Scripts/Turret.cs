using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity setup fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Use this for initialization
    void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (target == null)
	        return;

	    Vector3 dir = target.position - transform.position;

	    Quaternion lookRotation = Quaternion.Lerp(partToRotate.rotation, Quaternion.LookRotation(dir), Time.deltaTime * turnSpeed);
	    Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0, rotation.y, 0);

	    if (fireCountdown <= 0)
	    {
	        Shoot();
	        fireCountdown = 1f / fireRate;
	    }

	    fireCountdown -= Time.deltaTime;
	}

    private void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        var shortestDistance = Mathf.Infinity;
        GameObject nearestEnemeny = null;

        foreach (var enemy in enemies)
        {
            var distanceToEnemeny = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemeny < shortestDistance)
            {
                shortestDistance = distanceToEnemeny;
                nearestEnemeny = enemy;
            }
        }

        if (nearestEnemeny != null && shortestDistance <= range)
        {
            target = nearestEnemeny.transform;
        }
        else
        {
            target = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
