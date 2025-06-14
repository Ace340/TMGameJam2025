using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{

    public enum Scene
    {
        MainMenuScene,
        MainScene,
        LoadingScene
    }

    private static Scene targetScene;

    /// <summary>
    /// Scene Loader
    /// </summary>
    /// <param name="targetSceneName"></param>
    public static void Load(Scene targetScene)
    {
        Loader.targetScene = targetScene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }
}
