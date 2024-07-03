using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Tooltip("生成するボールのプレハブ")]
    [SerializeField]
    GameObject _ballPrefab;
    [Tooltip("スポナーの位置を中心としてボールが生成される範囲")]
    [SerializeField]
    float _spawnRangeX;
    [Tooltip("ボールの生成間隔")]
    [SerializeField]
    float _spawnInterval;

    float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _spawnInterval)
        {
            _timer = 0f;
            Instantiate(_ballPrefab, new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), transform.position.y, 0f), Quaternion.identity);
        }
    }
}
