using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private float m_speed;

    void Update()
    {
        // move player with W A S D
        float walk = Input.GetAxisRaw("Vertical") * m_speed * Time.deltaTime;
        float strafe = Input.GetAxisRaw("Horizontal") * m_speed * Time.deltaTime;
        transform.Translate(strafe, 0, walk);
    }
}
