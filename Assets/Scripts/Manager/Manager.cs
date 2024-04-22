using UnityEngine;

public static class Manager
{
    public static GameManager Game { get { return GameManager.Instance; } }
    public static DataManager Data { get { return DataManager.Instance; } }
    public static PoolManager Pool { get { return PoolManager.Instance; } }
    public static ResourceManager Resource { get { return ResourceManager.Instance; } }
    public static SceneManager Scene { get { return SceneManager.Instance; } }
    public static SoundManager Sound { get { return SoundManager.Instance; } }
    public static UIManager UI { get { return UIManager.Instance; } }
    public static JanggiLogic JanggiLogic { get {  return JanggiLogic.Instance; } }
    public static JanggiTurn JanggiTurn { get { return JanggiTurn.Instance; } }
    public static JanggiCamera JanggiCamera { get { return JanggiCamera.Instance; } }
    public static JanggiLoadManager JanggiLoadManager { get { return JanggiLoadManager.Instance; } }
    public static KillListManager KillListManager { get {  return KillListManager.Instance; } }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        GameManager.ReleaseInstance();
        DataManager.ReleaseInstance();
        PoolManager.ReleaseInstance();
        ResourceManager.ReleaseInstance();
        SceneManager.ReleaseInstance();
        SoundManager.ReleaseInstance();
        UIManager.ReleaseInstance();

        GameManager.CreateInstance();
        DataManager.CreateInstance();
        PoolManager.CreateInstance();
        ResourceManager.CreateInstance();
        SceneManager.CreateInstance();
        SoundManager.CreateInstance();
        UIManager.CreateInstance();
        Data.LoadData(1);
    }
}
