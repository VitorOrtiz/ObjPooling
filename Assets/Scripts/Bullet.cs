using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Speed;
    public float lifetime;
    ObjPooler pool;
    // Use this for initialization
    void Start () {
        pool = ObjPooler.pooler;
        Invoke("Reset", lifetime);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }
    private void Reset()
    {
        pool.Requeue("Bullet", gameObject);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            Reset();

    }
}
