﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public float explosionRadius = 0f;
    public string enemyTag;

    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        var dir = target.position - transform.position;

        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        GameObject effectIn = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIn, 5);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    private void Explode()
    {
        var colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (var collider1 in colliders.Where(col => col.tag == enemyTag))
        {
            Damage(collider1.transform);
        }
    }

    private void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
