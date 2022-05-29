using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject scoreTxt;
    GameObject scoreDump;

    public GameObject explosion_0;
    public float speed;
    public float speedrot;
    // Start is called before the first frame update
    void Start()
    {
        scoreTxt = GameObject.FindGameObjectWithTag("Score");
        scoreDump = GameObject.FindGameObjectWithTag("ScoreRes");

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
        transform.Rotate(speedrot * Time.deltaTime, speedrot * Time.deltaTime, speedrot * Time.deltaTime, Space.Self);
    }
    private void OnTriggerEnter(Collider col)
    {
        if ((col.tag == "PlayerShip") || (col.tag == "PlayerBullet"))
        {
            Kaboom();

            scoreTxt.GetComponent<GameScore>().Score += 100;
            scoreDump.GetComponent<GameScore>().Score += 100;

            Destroy(gameObject);
        }
    }

    void Kaboom()
    {
        GameObject explosion = (GameObject)Instantiate(explosion_0);

        explosion.transform.position = transform.position;
    }
}
