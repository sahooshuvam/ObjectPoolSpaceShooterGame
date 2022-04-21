using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public GameObject bullet;
    public Vector3 offsetValue;

    public int health = 100;

    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * playerSpeed * inputY * Time.deltaTime);
        transform.Translate(Vector3.right * playerSpeed  * inputX * Time.deltaTime);
        if (transform.position.y > 3.25f)
        {
            transform.position = new Vector3(transform.position.x, 3.25f, 0);
        }
        else if (transform.position.y < -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, 0);
        }
        if (transform.position.x > 7.9f)
        {
            transform.position = new Vector3(7.9f, transform.position.y, 0);
        }
        else if (transform.position.x < -7.9f)
        {
            transform.position = new Vector3(-7.9f, transform.position.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletFromPool = ObjectPoolScripts.Instance.GetObjectsFromPool("Bullet");
            bulletFromPool.transform.position = this.transform.position + offsetValue;
            bulletFromPool.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int healthDecrease = 10;
        if (collision.gameObject.tag == "Astroid")
        {
            health =  Mathf.Clamp(health - healthDecrease,0,100);
            healthText.text = health.ToString();
            Debug.Log(health);
            GameObject tempAstroid = collision.gameObject;
            tempAstroid.SetActive(false);

        }
    }
}
