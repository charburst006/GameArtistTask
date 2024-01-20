using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PartController : MonoBehaviour
{
    [SerializeField]
    public SOPartsSet PartsSet;

    [SerializeField]
    public UnityEvent<Sprite> OnPartUpdated;

    [SerializeField]
    public UnityEvent<Color> OnColorUpdated;

    public int PartsCount => PartsSet == null ? 0 : PartsSet.Sprites.Count;
    public Sprite CurrentPartSprite => PartsCount == 0 ? null : PartsSet.Sprites[_currentIndex];

    int _currentIndex;

    private void Start()
    {
        _currentIndex = 0;

        InvokeUpdateSprite();
        ChangeColor(Color.white);
    }

    void InvokeUpdateSprite()
    {
        if(PartsCount == 0)
        {
            Debug.LogError("No parts found.");
            return;
        }

        OnPartUpdated?.Invoke(CurrentPartSprite);
    }

    public void GoToNextSprite()
    {
        if(PartsCount == 0)
        {
            Debug.LogError("No parts found.");
            return;
        }

        _currentIndex = (_currentIndex + 1) % PartsCount;

        InvokeUpdateSprite();
    }

    public void GoToPreviousSprite()
    {
        if(PartsCount == 0)
        {
            Debug.LogError("No parts found.");
            return;
        }

        _currentIndex = (_currentIndex - 1 + PartsCount) % PartsCount;

        InvokeUpdateSprite();
    }

    public void ChangeColor(Color color)
    {
        OnColorUpdated?.Invoke(color);
    }
}
