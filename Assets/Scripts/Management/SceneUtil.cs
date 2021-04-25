using UnityEngine.SceneManagement;

public static class SceneUtil
{
    private const string SCENE_TITLE = "TitleScreen";
    private const string SCENE_GAME = "GameScene";
    
    public static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public static void ToMainMenu()
    {
        SceneManager.LoadScene(SCENE_TITLE);
    }
    public static void ToGame()
    {
        SceneManager.LoadScene(SCENE_GAME);
    }
}