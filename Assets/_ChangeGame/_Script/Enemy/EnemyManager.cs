using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChangeGame.Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        //�v���n�u���i�[����ϐ�
        [SerializeField] private List<GameObject> _enemyPrefab = new List<GameObject>();    //�G�̃v���n�u���X�g
        [SerializeField] private List<GameObject> _enemySpawnPoint = new List<GameObject>();   //SpawnPoint�̃��X�g
        [SerializeField] private int _maxEnemyCount = 50;   //��������G�̍ő吔
        [SerializeField] private float _spawnInterval = 40.0f;

        private float _nextSpawnTime;
        private List<Transform> _EnemyInstaces = new List<Transform>(); //�������ꂽ�G��Transform���i�[���郊�X�g

        private void Start()
        {
            //�G�̃v���n�u���X�g�̐�����ϓ���_maxEnemyCount�̓G�𐶐�����EnemyInstaces�Ɋi�[
            for (int i = 0; i < _enemyPrefab.Count; i++)
            {
                for (int j = 0; j < _maxEnemyCount / _enemyPrefab.Count; j++)
                {
                    //���̃I�u�W�F�N�g�̎q�I�u�W�F�N�g�Ƃ��ēG�𐶐�
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
            //_EnemyInstaces����SetActive��false�̓G��T���ă����_����_enemySpawnPoint����w�肳�ꂽ�ʒu�ɐ���
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
