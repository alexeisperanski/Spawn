using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemy;
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
                GameObject newEnemy = Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
                yield return waitForSeconds;
                Destroy(newEnemy);
            }
        }
    }
}
