using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChangeGame.Item
{
    public class ItemManager : MonoBehaviour
    {
        [SerializeField] private List<ItemSpawner> _itemSpawners = new List<ItemSpawner>();
        [SerializeField] private int _maxItemCount = 5;
        [SerializeField] private float _spawnMinInterval = 5.0f;
        [SerializeField] private float _spawnMaxInterval = 10.0f;
        private float _nextSpawnTime;

        private void Awake()
        {
            _nextSpawnTime = Time.time + Random.Range(_spawnMinInterval, _spawnMaxInterval);
        }


        private void Update()
        {
            if (_nextSpawnTime <= Time.time)
            {
                _nextSpawnTime = Time.time + Random.Range(_spawnMinInterval, _spawnMaxInterval);
                if(ItemSpawner.ItemSpawnCount >= _maxItemCount) return;
                /*
                foreach (ItemSpawner spawner in _itemSpawners)
                {
                    if (spawner.SpawnItem()) break;
                }
                */
                
                //リストにあるものをランダムでスポーンさせる
                int index = Random.Range(0, _itemSpawners.Count);
                _itemSpawners[index].SpawnItem();
            }
        }
    }
}
