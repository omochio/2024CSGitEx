using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    Transform _paddleTf;
    [Tooltip("�p�h���̈ړ����x")]
    [SerializeField, Min(0f)]
    float _paddleSpd;

    void Update()
    {
        // �L�[�{�[�h���ڑ�����Ă��Ȃ����null
        if (Keyboard.current == null)
        {
            return;
        }

        // ���ړ�
        if (Keyboard.current.aKey.isPressed)
        {
            transform.position += _paddleSpd * Time.deltaTime * Vector3.left;
        }
        // �E�ړ�
        if (Keyboard.current.dKey.isPressed)
        {
            transform.position += _paddleSpd * Time.deltaTime * Vector3.right;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // �{�[���Ƃ̏Փˎ��Ƀ{�[����j��
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (collision.gameObject != null)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
