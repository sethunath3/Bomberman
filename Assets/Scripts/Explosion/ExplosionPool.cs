using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BomberMan.Generics;

namespace BomberMan.Explosion
{
    public class ExplosionPool : GenericPool<ExplosionView>
    {
        public override ExplosionView CreateNewPooledItem()
        {
            return Instantiate(ExplosionService.Instance.ExplosionPrefab);
        }
    }
}
