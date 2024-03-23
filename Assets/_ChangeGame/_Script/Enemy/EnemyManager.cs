using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChangeGame.Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        //プレハブを格納する変数
        [SerializeField] private List<GameObject> _enemyPrefab = new List<GameObject>();    //敵のプレハブリスト
        [SerializeField] private List<GameObject> _enemySpawnPoint = new List<GameObject>();   //SpawnPointのリスト
        [SerializeField] private int _maxEnemyCount = 50;   //生成する敵の最大数
        [SerializeField] private float _spawnInterval = 40.0f;

        private float _nextSpawnTime;
        private List<Transform> _EnemyInstaces = new List<Transform>(); //生成された敵のTransformを格納するリスト

        private void Start()
        {
            //敵のプレハブリストの数から均等に_maxEnemyCount個の敵を生成してEnemyInstacesに格納
            for (int i = 0; i < _enemyPrefab.Count; i++)
            {
                for (int j = 0; j < _maxEnemyCount / _enemyPrefab.Count; j++)
                {
                    //このオブジェクトの子オブジェクトとして敵を生成
                    GameObject enemy = Instantiate(_enemyPrefab[i], transform);
                    _EnemyInstaces.Add(enemy.transform);
                    enemy.SetActive(false);
                }
            }

        }

        private void Update()
        {


        }

        private void SpawnEnemy()
        {
            //_EnemyInstacesからSetActiveがfalseの敵を探してランダムに_enemySpawnPointから指定された位置に生成
            for (int i = 0; i < _EnemyInstaces.Count; i++)
            {
                if (!_EnemyInstaces[i].gameObject.activeSelf)
                {
                    int index = Random.Range(0, _enemySpawnPoint.Count);
                    _EnemyInstaces[i].position = _enemySpawnPoint[index].transform.position;
                    _EnemyInstaces[i].gameObject.SetActive(true);
                    break;
                }
            }  

        }

    }

}
