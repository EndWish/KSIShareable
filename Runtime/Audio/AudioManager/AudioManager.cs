using KSIShareable.Core;
using KSIShareable.Editor;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

namespace KSIShareable.Audio
{
    public class AudioManager : MonoSingleton<AudioManager>
    {
        [ShowScriptableObject, Space(10)]
        [SerializeField, Required] private AudioLibrary audioLibrary;

        [SerializeField, Range(0, 1)] private float bgmVolume = 0.5f;
        public float BgmVolume {
            get { return bgmVolume; }
            set {
                bgmVolume = value;
                if (bgmSources != null) {
                    for (int i = 0; i < bgmSources.Length; i++) {
                        bgmSources[i].volume = bgmVolume;
                    }
                }
            }
        }
        [SerializeField] private AudioMixerGroup bgmMixerGroup;
        public AudioMixerGroup BgmMixerGroup {
            get { return bgmMixerGroup; }
            set {
                bgmMixerGroup = value;
                if (bgmSources != null) {
                    for (int i = 0; i < bgmSources.Length; i++) {
                        bgmSources[i].outputAudioMixerGroup = bgmMixerGroup;
                    }
                }
            }
        }

        private AudioSource[] bgmSources;
        private int curBgmIndex;
        private AudioSource curBgmSource {
            get { return bgmSources[curBgmIndex]; }
        }
        private AudioSource prevBgmSource {
            get { return bgmSources[(curBgmIndex + 1) % 2]; }
        }
        private Coroutine fadeCoroutine;

        [Space(10)]
        [SerializeField, Range(0, 1)] private float sfxVolume = 0.5f;
        public float SfxVolume {
            get { return sfxVolume; }
            set {
                sfxVolume = value;
                if (sfxSources != null) {
                    for(int i = 0; i < sfxSources.Length; i++) {
                        sfxSources[i].volume = sfxVolume;
                    }
                }
            }
        }
        [SerializeField] private AudioMixerGroup sfxMixerGroup;
        public AudioMixerGroup SfxMixerGroup {
            get { return sfxMixerGroup; }
            set {
                sfxMixerGroup = value;
                if (sfxSources != null) {
                    for (int i = 0; i < sfxSources.Length; i++) {
                        sfxSources[i].outputAudioMixerGroup = sfxMixerGroup;
                    }
                }
            }
        }

        [SerializeField] private int channelCount = 16;
        public int ChannelCount { get { return channelCount; } }
        protected AudioSource[] sfxSources;
        private int channelIndex;

        protected override void Awake() {
            base.Awake();
            if (gameObject.IsDestroyed()) {
                return;
            }
            audioLibrary.Init();
            Init();
        }

        private void Init() {
            // 배경음 플레이어 초기화
            GameObject bgmObject = new GameObject("BgmPlayer");
            bgmObject.transform.SetParent(this.transform);

            bgmSources = new AudioSource[2];
            for (int i = 0; i < 2; i++) {
                bgmSources[i] = bgmObject.AddComponent<AudioSource>();
                bgmSources[i].playOnAwake = false;
                bgmSources[i].loop = true;
                bgmSources[i].volume = BgmVolume;
                bgmSources[i].outputAudioMixerGroup = bgmMixerGroup;
            }

            // 효과음 플레이어 초기화
            GameObject sfxObject = new GameObject("SfxPlayer");
            sfxObject.transform.SetParent(this.transform);

            sfxSources = new AudioSource[channelCount];
            for(int i = 0; i < channelCount; i++) {
                sfxSources[i] = sfxObject.AddComponent<AudioSource>();
                sfxSources[i].playOnAwake = false;
                sfxSources[i].volume = sfxVolume;
                sfxSources[i].outputAudioMixerGroup = sfxMixerGroup;
            }
        }

        public void FadeBgm(string key, float duration) {
            AudioClip clip = audioLibrary.GetClip(key);
            if (clip == null) {
                Debug.LogWarning($"BGM '{key}' not found in AudioLibrary!");
                return;
            }

            FadeBgm(clip, duration);
        }
        public void FadeBgm(AudioClip clip, float duration) {
            if(fadeCoroutine != null) {
                StopCoroutine(fadeCoroutine);
            }
            fadeCoroutine = StartCoroutine(CoFadeBgm(clip, duration));
        }
        private IEnumerator CoFadeBgm(AudioClip clip, float duration) {
            curBgmIndex = (curBgmIndex + 1) % 2;

            curBgmSource.clip = clip;
            curBgmSource.volume = 0f;
            curBgmSource.Play();
            float prevBgmMaxVolume = prevBgmSource.volume;

            float time = 0;
            while (time < duration) {
                time += Time.deltaTime;
                float t = Mathf.Min(1f, time / duration);

                prevBgmSource.volume = Mathf.Lerp(prevBgmMaxVolume, 0, t);
                curBgmSource.volume = Mathf.Lerp(0, BgmVolume, t);

                yield return null;
            }

            prevBgmSource.Stop();
        }

        public void FadeOutBgm(float duration) {
            if (fadeCoroutine != null) {
                StopCoroutine(fadeCoroutine);
            }
            fadeCoroutine = StartCoroutine(CoFadeOutBgm(duration));
        }
        private IEnumerator CoFadeOutBgm(float duration) {
            curBgmIndex = (curBgmIndex + 1) % 2;
            curBgmSource.Stop();
            float prevBgmMaxVolume = prevBgmSource.volume;

            float time = 0;
            while (time < duration) {
                time += Time.deltaTime;
                float t = Mathf.Min(1f, time / duration);

                prevBgmSource.volume = Mathf.Lerp(prevBgmMaxVolume, 0, t);

                yield return null;
            }

            prevBgmSource.Stop();
        }

        public void PlayBgm(string key) {
            AudioClip clip = audioLibrary.GetClip(key);
            if (clip == null) {
                Debug.LogWarning($"BGM '{key}' not found in AudioLibrary!");
                return;
            }

            PlayBgm(clip);
        }
        public void PlayBgm(AudioClip clip) {
            curBgmSource.clip = clip;
            curBgmSource.volume = BgmVolume;
            curBgmSource.Play();
        }
        public void StopBgm() {
            curBgmSource.Stop();
        }
        public void PauseBgm() {
            curBgmSource.Pause();
        }
        public void UnPauseBgm() {
            curBgmSource.UnPause();
        }

        public void PlaySfx(string key) {
            AudioClip clip = audioLibrary.GetClip(key);
            if (clip == null) {
                Debug.LogWarning($"SFX '{key}' not found in AudioLibrary!");
                return;
            }

            PlaySfx(clip);
        }
        public void PlaySfx(AudioClip clip) {
            for (int i = 0; i < channelCount; i++) {
                int loopIndex = (channelIndex + 1 + i) % channelCount;

                if (sfxSources[loopIndex].isPlaying)
                    continue;

                sfxSources[loopIndex].clip = clip;
                sfxSources[loopIndex].Play();
                channelIndex = loopIndex;
                break;
            }
        }
    }
}