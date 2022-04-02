using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _waintTimeForSpawn = 2f;

    private Coroutine _spawn;

    private void OnEnable()
    {
        _spawn = StartCoroutine(SpawnEnemy());
    }

    private void OnDisable()
    {
        StopCoroutine(_spawn);
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForSeconds = new WaitForSeconds(_waintTimeForSpawn);
        bool isActive = true;

        while (isActive)
        {
            foreach (Transform spawnPoint in _spawnPoints)
            {
                Enemy newEnemy = Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
                yield return waitForSeconds;
                Destroy(newEnemy.gameObject);
            }
        }
    }
}
