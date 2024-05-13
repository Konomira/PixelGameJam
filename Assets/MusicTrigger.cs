using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public enum SceneType { Menu, Credits, Game}
    public SceneType sceneType;
    private void Start()
    {
        if(sceneType == SceneType.Game)
            MusicController.SwitchToGame();

        if (sceneType == SceneType.Menu)
            MusicController.SwitchToMenu();

        if (sceneType == SceneType.Credits)
            MusicController.SwitchToCredits();
    }
}
