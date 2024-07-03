using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    Transform _paddleTf;
    [Tooltip("パドルの移動速度")]
    [SerializeField, Min(0f)]
    float _paddleSpd;

    void Update()
    {
        // キーボードが接続されていなければnull
        if (Keyboard.current == null)
        {
            return;
        }

        // 左移動
        if (Keyboard.current.aKey.isPressed)
        {
            transform.position += _paddleSpd * Time.deltaTime * Vector3.left;
        }
        // 右移動
        if (Keyboard.current.dKey.isPressed)
        {
            transform.position += _paddleSpd * Time.deltaTime * Vector3.right;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // ボールとの衝突時にボールを破壊
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (collision.gameObject != null)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
