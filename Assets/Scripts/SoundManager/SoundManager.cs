using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public List<AudioClip> BGMs = new List<AudioClip>();
    public List<AudioClip> SFXs = new List<AudioClip>();

    public bool isMute;
    private BGMIndex curBGM;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBGM(BGMIndex bgmIndex, float volume = 1)
    {
        if (isMute)
            return;
        StopBGM(curBGM);
        EazySoundManager.PlayMusic(BGMs[(int)bgmIndex], volume);
        curBGM = bgmIndex;
    }
    public void PauseBGM(BGMIndex bgmIndex)
    {
        Audio audio = EazySoundManager.GetMusicAudio(BGMs[(int)bgmIndex]);
        if (audio != null)
        {
            audio.Pause();
        }
    }
    
    public void StopBGM(BGMIndex bgmIndex)
    {
        Audio audio = EazySoundManager.GetMusicAudio(BGMs[(int)bgmIndex]);
        if (audio != null)
        {
            audio.Stop();
        }
    }
    public void PlaySFX(SFXIndex sfxindex, bool isloop= false)
    {
        if (isMute)
        {
            return;
        }
        EazySoundManager.PlaySound(SFXs[(int)sfxindex], isloop);
    }
    public void PauseSFX(SFXIndex sfxindex)
    {
        Audio audio = EazySoundManager.GetSoundAudio(SFXs[(int)sfxindex]);
        if (audio != null)
        {
            audio.Pause();
        }

    }
    public void StopSFX(SFXIndex sfxindex)
    {
        Audio audio = EazySoundManager.GetSoundAudio(SFXs[(int)sfxindex]);
        if (audio != null)
        {
            audio.Stop();
        }
    }
    public void Mute()
    {
        isMute = true;
        for(SFXIndex i=SFXIndex.ClickFX; i < SFXIndex.Count; i++)
        {
            PauseSFX(i);
        }
        // Pause BGM
        for(BGMIndex i = BGMIndex.UIBGM; i < BGMIndex.Count; i++)
        {
            PauseBGM(i);
        }
    }
    public void Unmute()
    {
        isMute = false;
        // Play BGM
        PlayBGM(curBGM);
    }
   
}

public enum BGMIndex
{
    UIBGM,
    GameplayBGM,
    BossBGM,
    Count
}

public enum SFXIndex
{
    ClickFX,
    FootStepFX,
    GameoverFX,
    HurtFX,
    VictoryFX,
    Count
}