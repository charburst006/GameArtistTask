using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartSearchController : MonoBehaviour
{
    public List<PartController> PartControllers;

    bool CompareQueryToTag(string tag, string query)
    {
        return tag == query;
    }

    public void OnSearchInputUpdated(string query)
    {
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
                    }
                }
            }
        }
    }    
}
