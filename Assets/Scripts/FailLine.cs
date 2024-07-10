using UnityEngine;

public class FailLine : MonoBehaviour
{
    [SerializeField]
    BallSpawner _spawner;
    [SerializeField]
    GameObject _gameOverText;

    void Awake()
    {
        transform.localScale = new Vector3(_spawner.SpawnRangeX, 1f, 1f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            _gameOverText.SetActive(true);
            Destroy(col.gameObject);
        }
    }
}
