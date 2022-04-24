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

    //切换场景，找到摄像机边缘并复制给cinemachine
    private void SwitchScenes()
    {
        GameObject walls = GameObject.FindGameObjectWithTag("SceneWall");

        PolygonCollider2D scnenWallShape = walls.GetComponent<PolygonCollider2D>();

        CinemachineConfiner2D confiner = GetComponent<CinemachineConfiner2D>();
        
        confiner.m_BoundingShape2D = scnenWallShape;

        confiner.InvalidateCache();
    }

    
}
