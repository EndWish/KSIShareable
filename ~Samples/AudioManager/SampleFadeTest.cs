using KSIShareable.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSIShareable.Samples
{
    internal class SampleFadeTest : MonoBehaviour
    {
        public string clipKey;
        public float duration = 1f;
        public void FadeBgm() {
            AudioManager.Instance.FadeBgm(clipKey, duration);
        }
    }
}