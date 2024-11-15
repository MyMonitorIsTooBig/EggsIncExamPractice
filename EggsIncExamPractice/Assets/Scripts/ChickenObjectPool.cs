using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ChickenObjectPool : MonoBehaviour
{
    public int maxPoolSize = 200;
    public int stackDefaultCapacity = 200;

    [SerializeField] GameObject chicken;

    [SerializeField] public Transform spawn;

    public IObjectPool<GameObject> Pool
    {
        get
        {
            if(_pool == null)
            {
                _pool =
                    new ObjectPool<GameObject>(
                        CreatedPooledItem,
                        OnTakeFromPool,
                        OnReturnedToPool,
                        OnDestroyPoolObject,
                        true,
                        stackDefaultCapacity,
                        maxPoolSize);
            }
            return _pool;
        }
    }

    public IObjectPool<GameObject> _pool;


    private GameObject CreatedPooledItem()
    {
        var go = Instantiate(chicken);

        ChickenBehavior _chicken = chicken.GetComponent<ChickenBehavior>();

        return go;
    }

    public void OnReturnedToPool(GameObject _chicken)
    {
        _chicken.gameObject.SetActive(false);
    }

    private void OnTakeFromPool(GameObject _chicken)
    {
        _chicken.gameObject.SetActive(true);
    }

    private void OnDestroyPoolObject(GameObject _chicken)
    {
        Destroy(_chicken.gameObject);
    }

    public void Spawn()
    {
        var _chicken = Pool.Get();

        _chicken.transform.position = spawn.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
