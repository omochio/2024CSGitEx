using JetBrains.Annotations;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    Transform _paddleTf;

    [Tooltip("�p�h���̈ړ����x"), SerializeField, Min(0f)]
    float _paddleSpd;

    [Tooltip("�_�b�V���̋���"), SerializeField, Min(0f)]
    float _dashPower;

    [Tooltip("�_�b�V���̎�������"), SerializeField, Min(0f)]
    float _dashDuration;

    [Tooltip("�_�b�V���̑��x�ψڃJ�[�u"), SerializeField]
    AnimationCurve _dashCurve;

    [Tooltip("�_�b�V���̃N�[���_�E���b��"), SerializeField, Min(0f)]
    float _dashCoolDownSec;
    bool _isDashCoolDown;

    void Start()
    {
        
    }


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

        //�_�b�V��
        if (Keyboard.current.spaceKey.isPressed && !_isDashCoolDown)
        {
            if (Keyboard.current.aKey.isPressed && Keyboard.current.dKey.isPressed)
            {
                StartCoroutine(DashCoolDown(Vector3.zero));
            }
            else if (Keyboard.current.aKey.isPressed)
            {
                StartCoroutine(DashCoolDown(Vector3.left));
            }
            else if (Keyboard.current.dKey.isPressed)
            {
                StartCoroutine(DashCoolDown(Vector3.right));
            }                
        }
    }

    IEnumerator DashCoolDown(Vector3 _dashDir)
    {
        _isDashCoolDown = true;
        float _elapsedTime = 0f;
        while(_dashDuration > _elapsedTime)
        {
            _elapsedTime += Time.deltaTime;
            float _progress = _elapsedTime / _dashDuration;
            transform.position += _dashDir * _dashCurve.Evaluate(_progress) * _dashPower;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(_dashCoolDownSec);
        _isDashCoolDown = false;
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
