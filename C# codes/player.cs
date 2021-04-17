using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {
    public float speed;
    public float jumps;
    public bool grounds;
    

    public bool jump;
  
    public bool wins = false;
    public Rigidbody2D rb2d;
    public Animator anim;
    public GameObject bullet;
    public GameObject bulletleft;
    Transform fireposition;
    public bool fires;
    public int currenthealth;
    public int maxhealth = 100;
    Transform players;

	// Use this for initialization
	void Start () {
        count = 0;
        Vector3 pos = transform.position;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        fireposition = transform.Find("fire position");
        currenthealth = ( maxhealth);
        players = transform.Find("player");
        

    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("grounded", grounds);
		if(anim.GetBool("jump") && ! grounds) anim.SetBool("jump", false);
		anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetButtonDown("Jump") && grounds)
        {
            float temp = speed;
            rb2d.AddForce(Vector2.up * jumps);
            jump = true;
			anim.SetBool("jump", true);
            speed = 0;
            speed = temp;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            fire();
            anim.Play("blast");
        }
        if (currenthealth > maxhealth)
        {
            currenthealth = maxhealth;
        }
        if (currenthealth <= 0)
        {
            death();
        } 
        if(wins == true)
        {
            Application.LoadLevel(3);
        }

    }
    void FixedUpdate()
    {
        float ins = Input.GetAxis("Horizontal");
        rb2d.AddForce((Vector2.right * speed)* ins);

    }
    void fire()
    {
        if (transform.localScale.x == 1) { 
            Instantiate(bullet, fireposition.position, Quaternion.identity);
         }
        if (transform.localScale.x == -1)
        {
            Instantiate(bulletleft, fireposition.position, Quaternion.identity);
        }
    }
    void death()
    {
        Destroy(gameObject, 5f);
        Application.LoadLevel(Application.loadedLevel);
       
    }
    public void Damage (int dam)
    {
        currenthealth -= dam;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
      
        
        if (other.gameObject.CompareTag("hp item"))
        {
            other.gameObject.SetActive(false);
            currenthealth = currenthealth + 35;
        }

    }
    
}
