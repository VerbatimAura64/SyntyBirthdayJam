using TMPro;
using UnityEngine;

public class FragmentManager : MonoBehaviour
{
    public static FragmentManager Instance;
    public TMP_Text fragmentText;

    private void Awake()
    {
        Instance = this;
    }

    public void Unlock(StoryFragment fragment)
    {
        Debug.LogError(fragment.fragmentText);
        //fragmentText.text = fragment.fragmentText;
        //show panel or play audio
    }

}
