using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    [Header("音乐数据库")]
    public SoundDetailsList_SO soundDetailsData;
    public SceneSoundList_SO sceneSoundData;

    [Header("AudioSource")]
    public AudioSource startAudio;
    public AudioSource repAudio;
    public AudioSource loopAudio;

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadEvent += OnAfterSceneLoadEvent;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadEvent -= OnAfterSceneLoadEvent;
    }

    private void OnAfterSceneLoadEvent()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        SceneSoundItem sceneSound = sceneSoundData.GetSceneSoundItem(currentScene);

        if(sceneSound == null)
            return;
        
        SoundDeails firstMusic = soundDetailsData.GetSoundDeails(sceneSound.FirstMusic);

        PlayMusicSoundClip(firstMusic);

    }

    /// <summary>
    /// 播放背景音乐第一段
    /// </summary>
    /// <param name="soundDeails"></param>
    private void PlayMusicSoundClip(SoundDeails soundDeails)
    {
        startAudio.clip = soundDeails.soundClip;
        if(startAudio.isActiveAndEnabled)
        {
            startAudio.Play();
        }
    }
}
