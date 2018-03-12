using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using TMPro;
using Kani.TMPro;

public class TextMeshProNonAllocUtilSample : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _uguiText;
    [SerializeField] private TextMeshProUGUI _uguiTextWithUnit;
    [SerializeField] private TextMeshPro _text;


    void Update()
    {
        Profiler.BeginSample("SetChar NonAlloc");
        _uguiText.SetCharNonAlloc(-Time.frameCount);
        Profiler.EndSample();

        Profiler.BeginSample("SetChar NonAlloc with Unit");
        _uguiTextWithUnit.SetCharNonAlloc(Time.frameCount, "m");
        Profiler.EndSample();

        _text.SetCharNonAlloc(Time.frameCount);
    }
}
