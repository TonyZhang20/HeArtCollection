using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class AudioManager : SingleTon<AudioManager>
{
    [Header("音乐数据库")]
    public SoundDetailsList_SO soundDetailsData;
    public SceneSoundList_SO sceneSoundData;

    [Header("AudioSource")]
    public AudioSource startAudio;
    public AudioSource repAudio;
    public AudioSource loopAudio;

    [Header("AudioMixer")]
    public AudioMixer audioMixer;

    [Header("Snapshots")]
    public AudioMixerSnapshot normalSnapShot;
    public AudioMixerSnapshot ambientSnapShot;
    public AudioMixerSnapshot muteSnapShot;
    private Coroutine soundRoutine;
    private Coroutine follow;
    private SoundName currentMusic;
    private bool isBegin = false;

    protected override void Awake()
    {
        base.Awake();
        OnAfterSceneLoadEvent();
    }
    private void OnEnable()
    {
        EventHandler.AfterSceneLoadEvent += OnAfterSceneLoadEvent;
        EventHandler.StartNewGameEvent += OnStartNewGameEvent;
        EventHandler.TimeLienStopped += OnTimeLineStoppedEvent;
    }
    private void OnDisable()
    {
        EventHandler.AfterSceneLoadEvent -= OnAfterSceneLoadEvent;
        EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
        EventHandler.TimeLienStopped -= OnTimeLineStoppedEvent;
    }

    private void OnStartNewGameEvent(int obj)
    {
        muteSnapShot.TransitionTo(0f);
        isBegin = true;
    }

    private void OnTimeLineStoppedEvent()
    {
        OnAfterSceneLoadEvent();
    }

    private void OnAfterSceneLoadEvent()
    {

        if(isBegin == true)
        {
            isBegin = false;
            return;
        }

        string currentScene = SceneManager.GetActiveScene().name;

        SceneSoundItem sceneSound = sceneSoundData.GetSceneSoundItem(currentScene);

        if (sceneSound == null)
            return;

        SoundDeails firstMusic = soundDetailsData.GetSoundDeails(sceneSound.FirstMusic);

        if (soundRoutine != null)
        {
            StopCoroutine(soundRoutine);
        }

        if (follow != null)
        {
            StopCoroutine(follow);
        }
        currentMusic = sceneSound.FirstMusic;
        soundRoutine = StartCoroutine(PlaySoundRoutine(firstMusic));
        follow = StartCoroutine(AudioPlayFinished(firstMusic.soundClip.length, null, sceneSound));

    }
    private IEnumerator AudioPlayFinished(float time, UnityAction callback, SceneSoundItem sceneSound)
    {
        yield return new WaitForSeconds(time);
        //声音播放完毕后之下往下的代码  
        #region   声音播放完成后执行的代码
        if (sceneSound.SecondMusic != SoundName.None && sceneSound.SecondMusic != currentMusic)
        {
            AfterSecondMusic(sceneSound);
            Debug.Log("RunSecond");
        }
        else if (sceneSound.LastMusic != SoundName.None && sceneSound.LastMusic != currentMusic)
        {
            AfterThirdMusic(sceneSound);
            Debug.Log("Run Third");
        }
        #endregion
    }
    private IEnumerator PlaySoundRoutine(SoundDeails music)
    {
        if (music != null)
        {
            ambientSnapShot.TransitionTo(3f);
            yield return new WaitForSeconds(1f);
            PlayMusicSoundClip(music, 3f);
        }
    }

    /// <summary>
    /// 播放背景音乐第一段
    /// </summary>
    /// <param name="soundDeails"></param>
    private void PlayMusicSoundClip(SoundDeails soundDeails, float TransationToTime)
    {
        audioMixer.SetFloat("MusicVolume", ConvertSoundVolume(soundDeails.soundVolume));
        startAudio.clip = soundDeails.soundClip;
        if (startAudio.isActiveAndEnabled)
        {
            startAudio.Play();
        }
        normalSnapShot.TransitionTo(TransationToTime);
    }

    public float ConvertSoundVolume(float amount)
    {
        return (amount * 100 - 80);
    }

    private void AfterSecondMusic(SceneSoundItem sceneSound)
    {
        currentMusic = sceneSound.SecondMusic;
        SoundDeails RepMusic = soundDetailsData.GetSoundDeails(sceneSound.SecondMusic);
        PlayMusicSoundClip(RepMusic, 0f);
        if (follow != null)
        {
            StopCoroutine(follow);
        }
        follow = StartCoroutine(AudioPlayFinished(RepMusic.soundClip.length, null, sceneSound));
    }

    private void AfterThirdMusic(SceneSoundItem sceneSound)
    {
        currentMusic = sceneSound.LastMusic;
        SoundDeails LastMusic = soundDetailsData.GetSoundDeails(sceneSound.LastMusic);
        PlayMusicSoundClip(LastMusic, 0f);
        if (follow != null)
        {
            StopCoroutine(follow);
        }
        follow = StartCoroutine(AudioPlayFinished(LastMusic.soundClip.length, null, sceneSound));
    }
}
