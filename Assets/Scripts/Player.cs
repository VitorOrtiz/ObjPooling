using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Transform gunpoint;
    ObjPooler pool;
    public float speed;
    private float turnSpeed;
    #region singleton
    public static Player player;
    private void Awake()
    {
        player = this;
    }
    #endregion
    // Use this for initialization
    void Start () {
        pool = ObjPooler.pooler;
        turnSpeed = 360 / 8;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
        float Movement = Input.GetKeyDown(KeyCode.LeftArrow) ? -1 : Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0;
        if (Movement != 0)
        {
            Vector3 newrotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + Movement * turnSpeed, transform.rotation.eulerAngles.z);//* speed
            transform.rotation = Quaternion.Euler(newrotation);
        }
    }

    void Shoot()
    {
        pool.SpawnFromPool("Bullet", gunpoint.position, transform.rotation, false);
    }
    
}
