using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{

    public Vector2 size;
    public Button button;
    public string nextSceneName;

    private MenuController controller;
    private void OnValidate()
    {
        size = GetComponent<RectTransform>().sizeDelta;
        button = GetComponent<Button>();
        controller = GetComponentInParent<MenuController>();
    }

    private void Awake()
    {
        button.onClick.AddListener(OnClick);
    }

    public void Highlight()
    {
        var rt = GetComponent<RectTransform>();
        rt.sizeDelta = size * 1.1f;
    }

    public void Unhighlight()
    {
        var rt = GetComponent<RectTransform>();
        rt.sizeDelta = size;
    }

    public void OnClick()
    {
        controller.nextScene = nextSceneName;
        controller.Close();
    }
}
