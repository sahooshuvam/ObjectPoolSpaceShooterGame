using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public GameObject bullet;
    public Vector3 offsetValue;
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
}
