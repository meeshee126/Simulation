using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseLook : MonoBehaviour
{

    private Vector2 m_mouseLook;
    private Vector2 m_smooth;

    [SerializeField]
    private float m_sensitivity = 5f, m_smoothing = 2f;

    private UnityEngine.GameObject m_player;

    void Start()
    {
        m_player = this.transform.parent.gameObject;
    }

    void Update()
    {
        Vector2 mouseVelocity = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseVelocity = Vector2.Scale(mouseVelocity, new Vector2(m_sensitivity * m_smoothing, m_sensitivity * m_smoothing));
        m_smooth.x = Mathf.Lerp(m_smooth.x, mouseVelocity.x, 1f / m_smoothing);
        m_smooth.y = Mathf.Lerp(m_smooth.y, mouseVelocity.y, 1f / m_smoothing);

        m_mouseLook += m_smooth;

        //clamp looking up and down
        m_mouseLook.y = Mathf.Clamp(m_mouseLook.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-m_mouseLook.y, Vector3.right);
        m_player.transform.localRotation = Quaternion.AngleAxis(m_mouseLook.x, m_player.transform.up);

    
    }
}
