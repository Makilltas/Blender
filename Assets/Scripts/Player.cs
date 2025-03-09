using UnityEngine;

public class Player : MonoBehaviour
{
    public float range = 10f;
    public int money = 100;
    public float fireRate = 1f; 
    public GameObject bulletPrefab; 
    public Transform firePoint; 

    private float fireCooldown = 0f; 

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        
        GameObject target = FindEnemyInRange();

        if (target != null && fireCooldown <= 0f)
        {
            ShootAtTarget(target);
            fireCooldown = 1f / fireRate; 
        }
    }

   
    GameObject FindEnemyInRange()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Emeny");
        GameObject closestEnemy = null;
        float closestDistance = range;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    
    void ShootAtTarget(GameObject target)
    {
        Vector3 direction = (target.transform.position - firePoint.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);

        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetDirection(direction);
    }
}
