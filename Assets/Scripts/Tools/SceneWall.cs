using UnityEngine;
using Cinemachine;

public class SceneWall : MonoBehaviour
{
    private void OnEnable()
    {
        EventHandler.AfterSceneLoadEvent += SwitchScenes;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadEvent -= SwitchScenes;
    }

    //�л��������ҵ��������Ե�����Ƹ�cinemachine
    private void SwitchScenes()
    {
        GameObject walls = GameObject.FindGameObjectWithTag("SceneWall");

        PolygonCollider2D scnenWallShape = walls.GetComponent<PolygonCollider2D>();

        CinemachineConfiner2D confiner = GetComponent<CinemachineConfiner2D>();
        
        confiner.m_BoundingShape2D = scnenWallShape;

        confiner.InvalidateCache();
    }

    
}
