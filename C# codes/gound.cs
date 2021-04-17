using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gound : MonoBehaviour {

    private plays player;

    private void Start()
    {
        player = gameObject.GetComponentInParent<plays>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.gounds = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.gounds = false;
    }
}
