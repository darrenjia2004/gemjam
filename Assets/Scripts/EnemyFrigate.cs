using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrigate : Enemy
{
    FrigateShoot shooter;

    public override void Start()
    {
        shooter = GetComponent<FrigateShoot>();
        base.Start();
    }
    protected override IEnumerator close()
    {
        rb.velocity = Vector3.zero;
        StartCoroutine(shoot());
        while (true)
        {
            Vector3 direction = player.transform.position - transform.position;
            rb.rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.velocity = Vector3.zero;
            yield return null;
        }
    }
    
    private IEnumerator shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.2f);
            shooter.BeginShooting();
        }

    }
}