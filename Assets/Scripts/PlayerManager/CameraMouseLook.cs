using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseLook : MonoBehaviour
{ 
    private Vector2 m_mouseLook;
    private Vector2 m_smooth;

    [SerializeField]
    private float m_sensitivity = 5f, m_smoothing = 2f;

    private GameObject m_player;

    void Start()
    {
        m_player = this.transform.parent.gameObject;
    }

    void Update()
    {
        // let the camera rotate by moving mosue axes
        Vector2 mouseRotation = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        // smooth camera rotation
        mouseRotation = Vector2.Scale(mouseRotation, new Vector2(m_sensitivity * m_smoothing, m_sensitivity * m_smoothing));
        m_smooth.x = Mathf.Lerp(m_smooth.x, mouseRotation.x, 1f / m_smoothing);
        m_smooth.y = Mathf.Lerp(m_smooth.y, mouseRotation.y, 1f / m_smoothing);

        m_mouseLook += m_smooth;

        //clamp looking up and down
        m_mouseLook.y = Mathf.Clamp(m_mouseLook.y, -90f, 90f);

        // rotates the camera
        transform.localRotation = Quaternion.AngleAxis(-m_mouseLook.y, Vector3.right);

        //rotates the player with camera on x axis
        m_player.transform.localRotation = Quaternion.AngleAxis(m_mouseLook.x, m_player.transform.up);
    }
}
