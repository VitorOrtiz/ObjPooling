using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public Transform[] SpawnPoints;
    private ObjPooler pool;
    public int SpawnLimit;
    public string enemytag;
    [HideInInspector]
    public int Spawncounter;
    public float SpawnTimer;
    public float SpawnJumps;


    #region Singleton 
    public static EnemySpawner spawner;
    private void Awake()
    {

        spawner = this;
    }
    #endregion

    // Use this for initialization
    void Start () {
        pool = ObjPooler.pooler;
	}
	
	// Update is called once per frame
	void Update () {
        if (Spawncounter < SpawnLimit)
        {
            SpawnTimer += Time.deltaTime;
            if (SpawnTimer > SpawnJumps)
            {
                Transform point = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
                Enemy enemy = pool.SpawnFromPool(enemytag, point.position, point.rotation, false).GetComponent<Enemy>();
                enemy.OnObjectSpawn();
                Spawncounter++;
                SpawnTimer = 0;
            }
        }
	}
    public void ResetEnemy(string Tag,GameObject enemy)
    {
        pool.Requeue(Tag, enemy);
        Spawncounter--;
    }
}
