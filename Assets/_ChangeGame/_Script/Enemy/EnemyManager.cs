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
        [SerializeField] private Transform _spawnPointParent;   //敵の生成位置を格納する親オブジェクト
        [SerializeField] private int _maxEnemyCount = 50;   //生成する敵の最大数
        [SerializeField] private float _spawnInterval = 40.0f;
        [SerializeField] private Transform _enemyParent;

        [Header("Debug")] 
        [SerializeField] private Transform _goal;

        private float _nextSpawnTime;
        private List<EnemyController> _EnemyInstaces = new List<EnemyController>(); //生成された敵のTransformを格納するリスト
        private List<Transform> _spawnPoints = new List<Transform>(); //SpawnPointのTransformを格納するリスト

        private void Start()
        {
            //敵のプレハブリストの数から均等に_maxEnemyCount個の敵を生成してEnemyInstacesに格納
            for (int i = 0; i < _enemyPrefab.Count; i++)
            {
                for (int j = 0; j < _maxEnemyCount / _enemyPrefab.Count; j++)
                {
                    //このオブジェクトの子オブジェクトとして敵を生成
                    GameObject enemy = Instantiate(_enemyPrefab[i], _enemyParent.transform);
                    if (enemy.TryGetComponent<EnemyController>(out EnemyController ec))
                    {
                        _EnemyInstaces.Add(ec);
                    }
                    else
                    {
                        Debug.LogError("EnemyControllerがアタッチされていません");
                        Destroy(enemy);
                    }
                }
            }

            //_spawnPointParentの子オブジェクトを取得して_spawnPointsに格納
            foreach (Transform spawnPoint in _spawnPointParent)
            {
                _spawnPoints.Add(spawnPoint);
            }

            //TODO::ゲーム開始の時間を入れるように
            _nextSpawnTime = Time.time + _spawnInterval;
        }

        private void Update()
        {
            if (_nextSpawnTime <= Time.time)
            {
                _nextSpawnTime = Time.time + _spawnInterval;
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            //_EnemyInstacesからSetActiveがfalseの敵を探してランダムに_enemySpawnPointから指定された位置に生成
            for (int i = 0; i < _EnemyInstaces.Count; i++)
            {
                if (!_EnemyInstaces[i].gameObject.activeSelf)
                {
                    int index = Random.Range(0, _spawnPoints.Count);
                    _EnemyInstaces[i].transform.position = _spawnPoints[index].transform.position;
                    _EnemyInstaces[i].gameObject.SetActive(true);
                    //TODO::プレイヤーのTransformを渡すように
                    _EnemyInstaces[i].Initialize(_goal.transform);
                    break;
                }
            }  

        }

    }

}
