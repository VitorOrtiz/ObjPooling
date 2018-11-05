using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed;
    Rigidbody rig;
    public string Tag;
	// Use this for initialization
	void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    public void OnObjectSpawn()
    {
        if(rig == null)
            rig = GetComponent<Rigidbody>();
        rig.velocity = -transform.position.normalized * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Limit" || other.tag =="Bullet")
        {
            Death();
        }

    }
    void Death()
    {
        gameObject.SetActive(false);
        EnemySpawner.spawner.ResetEnemy(Tag, gameObject);
    }
}
