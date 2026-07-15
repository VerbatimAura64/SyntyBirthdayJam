using TMPro;
using UnityEngine;
using Harborview.GameTools;

public class FragmentManager : MonoBehaviour, IFragmentDisplay
{
    [field: SerializeField] public GameObject Panel { get; set; }
    public TMP_Text fragmentText;

    private void Awake()
    {
        
        Panel.SetActive(false);
    }

    public void Unlock(StoryFragment fragment)
    {
        //Debug.LogError(fragment.fragmentText);
        fragmentText.text = fragment.fragmentText;
        Panel.SetActive(true);
        //show panel or play audio
    }

    public void ClosePanel() => Panel.SetActive(false);

    void IFragmentDisplay.Unlock(StoryFragment fragment)
    {
        Unlock(fragment);
    }

    void IFragmentDisplay.ClosePanel()
    {
        ClosePanel();
    }
}
