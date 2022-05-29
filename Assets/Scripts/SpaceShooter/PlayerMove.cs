using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject GameManager;

    public GameObject Hp1;
    public GameObject Hp2;
    public GameObject Hp3;
    public GameObject Bullet;
    public GameObject BulletPosition;
    public float speed;
    private float timer;
    public float coef;
    public GameObject explosion_0;
    float tiltAngle = -25.0f;
    float smooth = 10f;

    const int MaxLives = 3;
    int lives;

    public void Init()
    {
        lives = MaxLives;
        Hp1.SetActive(true);
        Hp2.SetActive(true);
        Hp3.SetActive(true);
        
        gameObject.SetActive(true);

    }

    // Start is called before the first frame update
    void Start()
    {
        
        lives = MaxLives;
        Hp1.SetActive(true);
        Hp2.SetActive(true);
        Hp3.SetActive(true);
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime * coef;
        float tiltAroundY = Input.GetAxis("Horizontal") * tiltAngle;
        Quaternion target = Quaternion.Euler(0, tiltAroundY, 0);
        while (timer <= 0)
        {
            GameObject bullet = (GameObject)Instantiate(Bullet);
            bullet.transform.position = BulletPosition.transform.position;
            timer = 5f;
        }
        float x = Input.GetAxisRaw("Horizontal");
        float y = 0;
        Vector2 direction = new Vector2(x, y).normalized;
        Move(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        
    }

    void Move(Vector2 direction) 
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);

        transform.position = pos;
        
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if((col.tag == "Asteroid") )
        {
            Kaboom();
            lives--;
            Debug.Log(lives);
            if(lives == 2)
            {
                Hp1.SetActive(false);
                Hp2.SetActive(true);
                Hp3.SetActive(true);
            }
            if (lives == 1)
            {
                Hp1.SetActive(false);
                Hp2.SetActive(false);
                Hp3.SetActive(true);
            }
            if (lives == 0) 
            {
                Hp1.SetActive(false);
                Hp2.SetActive(false);
                Hp3.SetActive(false);
                //Суда впаять Гамовер
                GameManager.GetComponent<GameManager>().SetGameManagerState(global::GameManager.GameManagerState.GameOver);

                gameObject.SetActive(false);
            }
               
        }
    }

    void Kaboom()
    {
        GameObject explosion = (GameObject)Instantiate(explosion_0);

        explosion.transform.position = transform.position;
    }
}
