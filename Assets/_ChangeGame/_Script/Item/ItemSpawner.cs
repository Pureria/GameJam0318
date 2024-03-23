using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Item
{
    public class ItemSpawner : MonoBehaviour
    {
        public static int ItemSpawnCount { get; private set; } = 0;
        
        [SerializeField] private ItemController _itemObject;

        private bool _IsSpawned;

        private void Start()
        {
            _itemObject.gameObject.SetActive(false);
            _IsSpawned = false;
        }

        private void OnEnable()
        {
            _itemObject.OnPickUpEvent += PickUp;
        }

        private void OnDisable()
        {
            _itemObject.OnPickUpEvent -= PickUp;
        }

        private void PickUp()
        {
            _itemObject.gameObject.SetActive(false);
            _IsSpawned = false;
            ItemSpawnCount--;
        }

        /// <summary>
        /// アイテムをスポーンさせる
        /// </summary>
        /// <returns>スポーンできなかった場合Falseが返される</returns>
        public bool SpawnItem()
        {
            if (_IsSpawned) return false;
            
            _itemObject.gameObject.SetActive(true);
            _IsSpawned = true;
            ItemSpawnCount++;
            return true;
        }
    }
}
