using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private T _prefab;

    private Queue<T> _pool = new Queue<T>();
    private List<T> _activeObjects = new List<T>();

    public IEnumerable<T> PooledObjects => _pool;

    public void Reset()
    {
        foreach (T obj in _activeObjects.ToArray())
        {
            PutObject(obj);
        }

        _activeObjects.Clear();
    }

    public virtual T GetObject()
    {
        T obj;

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

    public void PutObject(T obj)
    {
        if (obj == null) return;

        _activeObjects.Remove(obj);
        _pool.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }
}