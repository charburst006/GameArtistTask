using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PartSearchController : MonoBehaviour
{
    [SerializeField]
    public List<PartController> PartControllers;

    [SerializeField]
    public UnityEvent<PartSO> OnMatch;

    [SerializeField]
    public UnityEvent OnNoMatch;

    bool CompareQueryToTag(string tag, string query)
    {
        return tag == query;
    }

    public void OnSearchInputUpdated(string query)
    {
        var match = false;

        foreach (var partController in PartControllers)
        {
            foreach (var part in partController.PartsSet.Parts)
            {
                foreach (var tag in part.Tags)
                {
                    if (CompareQueryToTag(tag, query))
                    {
                        var partIndex = partController.PartsSet.Parts.IndexOf(part);
                        partController.SetCurrentPart(partIndex);
                        OnMatch?.Invoke(part);
                        match = true;
                    }
                }
            }
        }

        if (!match)
        {
            OnNoMatch?.Invoke();
        }
    }    
}
