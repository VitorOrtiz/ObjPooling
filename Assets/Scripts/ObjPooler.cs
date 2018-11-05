using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPooler : MonoBehaviour {
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> PoolDic = new Dictionary<string, Queue<GameObject>>();

    #region Singleton 
    public static ObjPooler pooler;
    private void Awake()
    {

        pooler = this;
    }
    #endregion

    // Use this for initialization
    void Start() {
        CreateObjs();

    }

    // Update is called once per frame
    void Update() {

    }
    void CreateObjs()
    {
        foreach (Pool pool in pools)

        {
            Transform Parent = new GameObject().transform;
            Parent.name = pool.tag + "Pool";
            Queue<GameObject> queueObj = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject objCreated = Instantiate(pool.prefab,Parent);
                objCreated.SetActive(false);
                queueObj.Enqueue(objCreated);
            }
            PoolDic.Add(pool.tag, queueObj);

        }

    }
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, bool requeue = true)
    {
        
        GameObject ObjSpawned = PoolDic[tag].Dequeue();

        ObjSpawned.SetActive(true);
        ObjSpawned.transform.position = position;
        ObjSpawned.transform.rotation = rotation;

        if (requeue)
            PoolDic[tag].Enqueue(ObjSpawned);
        return ObjSpawned;
    }
    public void Requeue(string tag, GameObject obj)
    {
        PoolDic[tag].Enqueue(obj);
    }
}
