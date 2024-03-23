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
        [SerializeField] private Transform _spawnPointParent;   //�G�̐����ʒu���i�[����e�I�u�W�F�N�g
        [SerializeField] private int _maxEnemyCount = 50;   //��������G�̍ő吔
        [SerializeField] private float _spawnInterval = 40.0f;
        [SerializeField] private Transform _enemyParent;

        [Header("Debug")] 
        [SerializeField] private Transform _goal;

        private float _nextSpawnTime;
        private List<EnemyController> _EnemyInstaces = new List<EnemyController>(); //�������ꂽ�G��Transform���i�[���郊�X�g
        private List<Transform> _spawnPoints = new List<Transform>(); //SpawnPoint��Transform���i�[���郊�X�g

        private void Start()
        {
            //�G�̃v���n�u���X�g�̐�����ϓ���_maxEnemyCount�̓G�𐶐�����EnemyInstaces�Ɋi�[
            for (int i = 0; i < _enemyPrefab.Count; i++)
            {
                for (int j = 0; j < _maxEnemyCount / _enemyPrefab.Count; j++)
                {
                    //���̃I�u�W�F�N�g�̎q�I�u�W�F�N�g�Ƃ��ēG�𐶐�
                    GameObject enemy = Instantiate(_enemyPrefab[i], _enemyParent.transform);
                    if (enemy.TryGetComponent<EnemyController>(out EnemyController ec))
                    {
                        _EnemyInstaces.Add(ec);
                    }
                    else
                    {
                        Debug.LogError("EnemyController���A�^�b�`����Ă��܂���");
                        Destroy(enemy);
                    }
                }
            }

            //_spawnPointParent�̎q�I�u�W�F�N�g���擾����_spawnPoints�Ɋi�[
            foreach (Transform spawnPoint in _spawnPointParent)
            {
                _spawnPoints.Add(spawnPoint);
            }

            //TODO::�Q�[���J�n�̎��Ԃ�����悤��
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
            //_EnemyInstaces����SetActive��false�̓G��T���ă����_����_enemySpawnPoint����w�肳�ꂽ�ʒu�ɐ���
            for (int i = 0; i < _EnemyInstaces.Count; i++)
            {
                if (!_EnemyInstaces[i].gameObject.activeSelf)
                {
                    int index = Random.Range(0, _spawnPoints.Count);
                    _EnemyInstaces[i].transform.position = _spawnPoints[index].transform.position;
                    _EnemyInstaces[i].gameObject.SetActive(true);
                    //TODO::�v���C���[��Transform��n���悤��
                    _EnemyInstaces[i].Initialize(_goal.transform);
                    break;
                }
            }  

        }

    }

}
