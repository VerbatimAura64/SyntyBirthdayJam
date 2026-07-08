using TMPro;
using UnityEngine;

public class FragmentManager : MonoBehaviour
{
    public static FragmentManager Instance;
    public GameObject panel;
    public TMP_Text fragmentText;

    private void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    public void Unlock(StoryFragment fragment)
    {
        //Debug.LogError(fragment.fragmentText);
        fragmentText.text = fragment.fragmentText;
        panel.SetActive(true);
        //show panel or play audio
    }

    public void ClosePanel() => panel.SetActive(false);
}
