using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayServices : MonoBehaviour {

    public static PlayServices playServices;

    private void Awake()
    {
        playServices = this;
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
        PlayGamesClientConfiguration Config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(Config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        SignIn();
    }

    private void SignIn()
    {
        Social.localUser.Authenticate(success => { });
    }

    #region Achievements

    public void UnlockAchievement(string id)
    {
        Social.ReportProgress(id, 100, (bool success) => { });
    }

    public void IncrementAchievement(string id, int stepToIncrement)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(id, stepToIncrement, success => { });
    }

    public void ShowAchievmentsUI()
    {
        Social.ShowAchievementsUI();
    }
    #endregion
}
