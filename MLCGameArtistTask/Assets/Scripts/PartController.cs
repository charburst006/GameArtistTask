using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PartController : MonoBehaviour
{
    [SerializeField]
    public SOPartsSet PartsSet;

    [SerializeField]
    public UnityEvent<PartSO> OnPartUpdated;

    [SerializeField]
    public UnityEvent<Color> OnColorUpdated;

    public int PartsCount => PartsSet == null ? 0 : PartsSet.Parts.Count;
    public PartSO CurrentPart => PartsCount == 0 ? null : PartsSet.Parts[_currentIndex];

    int _currentIndex;

    private void Start()
    {
        _currentIndex = 0;

        InvokeUpdatePart();
        ChangeColor(Color.white);
    }

    void InvokeUpdatePart()
    {
        if(PartsCount == 0)
        {
            Debug.LogError("No parts found.");
            return;
        }

        OnPartUpdated?.Invoke(CurrentPart);
    }

    public void GoToNextPart()
    {
        if(PartsCount == 0)
        {
            Debug.LogError("No parts found.");
            return;
        }

        _currentIndex = (_currentIndex + 1) % PartsCount;

        InvokeUpdatePart();
    }

    public void GoToPreviousPart()
    {
        if(PartsCount == 0)
        {
            Debug.LogError("No parts found.");
            return;
        }

        _currentIndex = (_currentIndex - 1 + PartsCount) % PartsCount;

        InvokeUpdatePart();
    }

    public void SetCurrentPart(int index)
    {
        if(PartsCount == 0)
        {
            Debug.LogError("No parts found.");
            return;
        }

        _currentIndex = index % PartsCount;

        InvokeUpdatePart();
    }

    public void ChangeColor(Color color)
    {
        OnColorUpdated?.Invoke(color);
    }
}
