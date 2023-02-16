using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform target;
    public GameManager gameManager;
    public float bulletSpeed;
    public bool hasTheBall;


    public bool shooting;
    Vector2 direction;
    CircleCollider2D circleCollider;


    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = target.position;
        direction = targetPos - (Vector2)transform.position;
        if (hasTheBall)
        {
            StartCoroutine(timeToShoot());
        }
    }
    private IEnumerator timeToShoot()
    {
        hasTheBall = false;
        circleCollider.enabled = false;
        shooting = true;
        yield return new WaitForSeconds(5);
        Debug.Log("Done");
        GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed);
        yield return new WaitForSeconds(2);
        circleCollider.enabled = true;
        shooting = false;
        gameManager.Check();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            hasTheBall = true;
            Destroy(collision.gameObject);
            Debug.Log("Destroyed The Ball");
        }
    }
}
