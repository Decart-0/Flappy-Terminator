using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<TObject> : MonoBehaviour where TObject : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private TObject _prefab;

    private Queue<TObject> _pool = new Queue<TObject>();
    private List<TObject> _activeObjects = new List<TObject>();

    public void Reset()
    {
        List<TObject> objectsToReset = new List<TObject>(_activeObjects);

        foreach (TObject obj in objectsToReset)
        {
            PutObject(obj);
        }

        _activeObjects.Clear();
    }

    public virtual TObject GetObject()
    {
        TObject obj;

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

    public void PutObject(TObject obj)
    {
        if (obj == null) return;

        _activeObjects.Remove(obj);
        _pool.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }
}