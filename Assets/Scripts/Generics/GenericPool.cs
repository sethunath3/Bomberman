using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BomberMan.Generics
{
    public abstract class GenericPool<T> : GenericMonoSingleton<GenericPool<T>> where T : class
    {
        private List<PooledItem<T>> poolList = new List<PooledItem<T>>();

        public T GetItem()
        {
            if(poolList.Count > 0)
            {
                PooledItem<T> item = poolList.Find(i => i.isItemUsed == false);
                if(item != null)
                {
                    item.isItemUsed = true;
                    return item.item;
                }
            }
            PooledItem<T> newPoolItem = new PooledItem<T>();
            newPoolItem.isItemUsed = true;
            newPoolItem.item = CreateNewPooledItem();
            poolList.Add(newPoolItem);
            return newPoolItem.item;
        }

        public void ReturnItem(T returnItem)
        {
            PooledItem<T> item = poolList.Find(i => i.item.Equals(returnItem));
            if(item != null)
            {
                item.isItemUsed = false;
            }
        }

        public abstract T CreateNewPooledItem();
        // {
        //     return (T) null;
        // }
    }

    public class PooledItem<T>
    {
        public bool isItemUsed;
        public T item;
    }
}
