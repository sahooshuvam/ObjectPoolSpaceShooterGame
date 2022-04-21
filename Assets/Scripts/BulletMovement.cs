using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletMovement : MonoBehaviour
{
    float bulletSpeed  = 12f;
 
    public Text scoreText;
    ScoreManager score;


    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * bulletSpeed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Astroid")
        {
            GameObject tempAstroid = collision.gameObject;
            GameObject tempBullet = this.gameObject;
            tempAstroid.SetActive(false);
            tempBullet.SetActive(false);
            score.ScoreCalculator(10);
          
        }
    }
}
