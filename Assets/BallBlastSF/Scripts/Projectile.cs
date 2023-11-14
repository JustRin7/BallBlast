using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;

    private int damage;

    private void Start()
    {
        Destroy(gameObject, lifetime);   
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;//transform.up - локальое направление вверх
        // или transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destructable destructable = collision.transform.root.GetComponent<Destructable>();//root - обращение к самому верхнему объекту, а не к дочерним

        if (destructable != null)
        {
            destructable.ApplyDamage(damage);
        }

        Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

}
