using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class GameObjectPool : MonoBehaviour
    {
        [SerializeField] private PoolObject prefab;
        [SerializeField] private int initialSize = 10;
        
        private Transform container;
        private readonly Queue<PoolObject> pooledObjects = new();
        
        private void Awake()
        {
            CreateContainer();
            WarmupPool();
        }

        private void CreateContainer()
        {
            var containerObj = new GameObject($"Container");
            this.container = containerObj.transform;
            this.container.SetParent(this.transform);
            containerObj.SetActive(false);
        }

        private void WarmupPool()
        {
            for (var i = 0; i < initialSize; i++)
            {
                InstantiateAndPoolNewObject();
            }
        }

        private void InstantiateAndPoolNewObject()
        {
            var newObject = Instantiate(this.prefab, this.container);
            newObject.SetPool(this);
            this.pooledObjects.Enqueue(newObject);
        }

        public PoolObject Get()
        {
            if (this.pooledObjects.Count == 0)
            {
                InstantiateAndPoolNewObject();
            }

            var obj = this.pooledObjects.Dequeue();
            return obj;
        }

        public void Pool(PoolObject obj)
        {
            obj.transform.SetParent(this.container);
            obj.Reset();
            
            this.pooledObjects.Enqueue(obj);
        }
    }
}