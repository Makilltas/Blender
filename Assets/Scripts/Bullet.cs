using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed = 20;
    public float lifeTime = 3;
    public int damage = 100;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (target == null) return;

        transform.LookAt(target);
        transform.position += transform.forward * speed * Time.deltaTime;


    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Emeny"))
        {
            var health = other.gameObject.GetComponent<Health>();
            health?.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}