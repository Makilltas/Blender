using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; 
    public float damage = 10f; 

    private Vector3 direction;

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, Camera.main.transform.position) > 100f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
           
            Enemy_Health enemyHealth = other.GetComponent<Enemy_Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
