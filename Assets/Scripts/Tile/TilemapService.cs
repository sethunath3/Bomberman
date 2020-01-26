using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using BomberMan.Generics;
using BomberMan.Explosion;
using BomberMan.Enemy;
using BomberMan.Gameplay;

namespace BomberMan.Grid
{
    public class TilemapService : GenericMonoSingleton<TilemapService>
    {
        public Tile wallTile;
        public Tile emptyTile;
        public Tile destructableTile;

        [SerializeField]
        private Tilemap tilemap;

        private List<Vector3Int> availableSlots;
        private List<Vector3Int> directions;

        private void Start()
        {
            directions = new List<Vector3Int>();
            directions.Add(new Vector3Int(-1,0,0));
            directions.Add(new Vector3Int(1,0,0));
            directions.Add(new Vector3Int(0,-1,0));
            directions.Add(new Vector3Int(0,1,0));
        }

        public void PopulateDestructableBlocks(int noOfBlocks)
        {
            RefreshAvailableSlots();
            for(int i =0; i< noOfBlocks; i++)
            {
                int randomCellId = Random.Range(0, availableSlots.Count);
                tilemap.SetTile(availableSlots[randomCellId], destructableTile);
                availableSlots.RemoveAt(randomCellId);
            }
        }

        public void PopuplateEnemies(int noOfEnemies)
        {
            for(int i =0; i< noOfEnemies; i++)
            {
                int randomCellId = Random.Range(0, availableSlots.Count);
                Vector2 localPosition = tilemap.GetCellCenterWorld(availableSlots[randomCellId]);
                EnemyService.Instance.SpawnEnemyAt(localPosition);
                availableSlots.RemoveAt(randomCellId);
            }
        }

        public void ExplodedAt(Vector2 position)
        {
            Vector3Int localPosition = tilemap.WorldToCell(position);

            MakeExplosionsIn(localPosition);
            MakeExplosionsIn(localPosition + new Vector3Int(-1,0,0));
            MakeExplosionsIn(localPosition + new Vector3Int(1,0,0));
            MakeExplosionsIn(localPosition + new Vector3Int(0,-1,0));
            MakeExplosionsIn(localPosition + new Vector3Int(0,1,0));

        }

        private void MakeExplosionsIn(Vector3Int tileLocation)
        {
            if (tilemap.GetTile(tileLocation) == destructableTile)
            {
                tilemap.SetTile(tileLocation, emptyTile);
            }

            if (tilemap.GetTile(tileLocation) != wallTile)
            {
                ExplosionService.Instance.CreateExplosionAt(tilemap.GetCellCenterWorld(tileLocation));
            }

        }

        private void RefreshAvailableSlots()
        {
            Vector3Int playerInitPosition = tilemap.LocalToCell(GameplayManager.Instance.GetPlayerPosition());
            availableSlots = new List<Vector3Int>();
            for(int i=tilemap.cellBounds.xMin; i<tilemap.cellBounds.xMax; i++)
            {
                for(int j=tilemap.cellBounds.yMin; j<=tilemap.cellBounds.yMax; j++)
                {
                    Vector3Int localPosition = new Vector3Int(i,j,0);
                    if(tilemap.HasTile(localPosition) && tilemap.GetTile(localPosition) == emptyTile && localPosition != playerInitPosition)
                    {
                        availableSlots.Add(localPosition);
                    }
                }
            }
        }

        public Vector2 GetRandomAdjacentTarget(Vector2 _position)
        {
            Vector3Int localPosition = tilemap.WorldToCell(_position);
            List<Vector3Int> availableTargets = new List<Vector3Int>();
            foreach(Vector3Int dir in directions)
            {
                if(tilemap.GetTile(localPosition + dir) == emptyTile)
                {
                    availableTargets.Add(localPosition + dir);
                }
            }
            if(availableTargets.Count > 0)
            {
                localPosition = availableTargets[Random.Range(0, availableTargets.Count)];
            }
            return tilemap.GetCellCenterWorld(localPosition);
        }
    }
}
