using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    Paddle _paddle;
    [SerializeField]
    BallSpawner _spawner;

    public void OnPressed()
    {
        _spawner.enabled = true;
        _paddle.enabled = true;
        gameObject.SetActive(false);
    }
}
