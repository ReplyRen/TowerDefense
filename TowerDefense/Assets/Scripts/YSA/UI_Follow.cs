using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Follow : MonoBehaviour
{
    public Camera m_camera;
    public Transform m_target;
    public RectTransform m_ui;
    public const float UI_Width = 1920f;
    public const float UI_Height = 1080f;
    public static float screen_width_half = Screen.width / 2;
    public static float screen_height_half = Screen.height / 2;
    public static float screen_width_ratio = UI_Width / Screen.width;
    public static float screen_height_ratio = UI_Height / Screen.height;


    private Vector3 position_sp;

    private void Awake()
    {
        if (m_camera == null)
        {
            m_camera = Camera.main;
        }
        if (m_ui == null && transform is RectTransform)
        {
            m_ui = (RectTransform)transform;
        }
    }

    private void LateUpdate()
    {
        if (m_target != null)
        {
            position_sp = m_camera.WorldToScreenPoint(m_target.position);
            Format_Position(ref position_sp);
            position_sp.y += 100;
            m_ui.localPosition = position_sp;
        }
    }

    private void Format_Position(ref Vector3 pos)
    {
        pos.x -= screen_width_half;
        pos.y -= screen_height_half;
        pos.x *= screen_width_ratio;
        pos.y *= screen_height_ratio;
    }
}
