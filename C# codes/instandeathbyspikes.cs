using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instandeathbyspikes : MonoBehaviour {

    public  int health;
    private player playe;
    public Animator anim;
    public Renderer rend;
    
    // Use this for initialization
    void Start () {
        playe = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        health = playe.currenthealth;
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("Player"))
        {
            playe.Damage(100);


        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
