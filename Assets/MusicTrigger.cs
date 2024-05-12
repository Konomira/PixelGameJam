using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public enum SceneType { Menu, Game}
    public SceneType sceneType;
    private void Start()
    {
        if(sceneType == SceneType.Game)
            MusicController.SwitchToGame();

        if (sceneType == SceneType.Menu)
            MusicController.SwitchToMenu();
    }
}
