using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    private Transform target;

    public float range = 15f;
    public string enemyTag = "Enemy";
    public Transform partToRotate;

    public float turnSpeed = 10f;

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
