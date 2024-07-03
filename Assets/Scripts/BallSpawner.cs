using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Tooltip("��������{�[���̃v���n�u")]
    [SerializeField]
    GameObject _ballPrefab;
    [Tooltip("�X�|�i�[�̈ʒu�𒆐S�Ƃ��ă{�[�������������͈�")]
    [SerializeField]
    float _spawnRangeX;
    [Tooltip("�{�[���̐����Ԋu")]
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
