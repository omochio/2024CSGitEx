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

    [Tooltip("パドルの移動速度"), SerializeField, Min(0f)]
    float _paddleSpd;

    [Tooltip("ダッシュの強さ"), SerializeField, Min(0f)]
    float _dashPower;

    [Tooltip("ダッシュの持続時間"), SerializeField, Min(0f)]
    float _dashDuration;

    [Tooltip("ダッシュの速度変移カーブ"), SerializeField]
    AnimationCurve _dashCurve;

    [Tooltip("ダッシュのクールダウン秒数"), SerializeField, Min(0f)]
    float _dashCoolDownSec;
    bool _isDashCoolDown;

    void Start()
    {
        
    }


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

        //ダッシュ
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
