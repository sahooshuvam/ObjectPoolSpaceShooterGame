using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement;
        movement = Input.GetAxis("Vertical") * playerSpeed;
        transform.Translate(0f,movement * Time.deltaTime,0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletFromPool = ObjectPoolScripts.Instance.GetObjectsFromPool("Bullet");
            bulletFromPool.SetActive(true);
        }
    }
}
