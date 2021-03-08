using UnityEngine;

[CreateAssetMenu(fileName = "GlobalSetting", menuName = "ScriptableObjects/GlobalSetting", order = 1)]
public class GlobalSettings : ScriptableObject
{    
    public static GlobalSettings Instance;

    public Material SuggestedArea;
    public Material NotSuggestedArea;
}
