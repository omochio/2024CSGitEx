using System.Collections;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    float _displayDuration;
    [SerializeField]
    GameObject _startButton;
    [SerializeField]
    Paddle _paddle;
    [SerializeField]
    BallSpawner _spawner;

    void OnEnable()
    {
        _paddle.enabled = false;
        _spawner.enabled = false;
        StartCoroutine(nameof(ShowTextCoroutine));
    }

    IEnumerator ShowTextCoroutine()
    {
        yield return new WaitForSeconds(_displayDuration);
        _startButton.SetActive(true);
        gameObject.SetActive(false);
    }
}
