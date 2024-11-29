using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;

    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health = 3;

    public GameObject effect;
    public TextMeshProUGUI healthDisplay;
    public GameObject panel;

    public Animator camAnim;

    private void Start()
    {
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }
    private void Update()
    {
        healthDisplay.text = health.ToString();

        if(health <= 0)
        {
            Time.timeScale = 0;
            Destroy(gameObject);
            panel.SetActive(true);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < maxHeight)
        {
            camAnim.SetTrigger("Shake");
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
        }
        else if (Input.GetKeyDown(KeyCode.S) && transform.position.y > minHeight)
        {
            camAnim.SetTrigger("Shake");
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
        }
    }
}

