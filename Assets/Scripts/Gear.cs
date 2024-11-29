using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    public GameObject effect;

    public Animator camAnim;

    private void Start()
    {
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }
    private void Update()
    {
        transform.Translate(Vector2.left * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            camAnim.SetTrigger("Shake");
            Instantiate(effect, transform.position, Quaternion.identity);
            other.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
        }
    }
}
