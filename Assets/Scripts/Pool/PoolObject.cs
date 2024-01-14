using System;
using UnityEngine;

namespace Pool
{
    public class PoolObject : MonoBehaviour
    {
        private GameObjectPool pool;

        public void SetPool(GameObjectPool pool)
        {
            this.pool = pool;
        }

        public virtual void Reset()
        {
        }
        
        public void PoolSelf()
        {
            if (pool == null)
            {
                throw new Exception("Pool is not set!");
            }
            
            this.pool.Pool(this);
        }
    }
}