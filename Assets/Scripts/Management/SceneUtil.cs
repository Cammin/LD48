using UnityEngine.SceneManagement;

public static class SceneUtil
{
    public static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
        
        
}