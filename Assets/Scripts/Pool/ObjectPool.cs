using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<Object> : MonoBehaviour where Object : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Object _prefab;

    private Queue<Object> _pool = new Queue<Object>();
    private List<Object> _activeObjects = new List<Object>();

    public IEnumerable<Object> PooledObjects => _pool;

    public void Reset()
    {
        foreach (Object obj in _activeObjects.ToArray())
        {
            PutObject(obj);
        }

        _activeObjects.Clear();
    }

    public virtual Object GetObject()
    {
        Object obj;

        if (_pool.Count == 0)
        {
            obj = Instantiate(_prefab, _container);
        }
        else
        {
            obj = _pool.Dequeue();
        }

        obj.gameObject.SetActive(true);
        _activeObjects.Add(obj);

        return obj;
    }

    public void PutObject(Object obj)
    {
        if (obj == null) return;

        _activeObjects.Remove(obj);
        _pool.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }
}