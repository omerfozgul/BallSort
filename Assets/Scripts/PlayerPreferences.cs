using UnityEngine;

public static class PlayerPrefKeys
{
    public static readonly string Noads = "Noads";
    public static readonly string Sound = "Sound";
    public static readonly string GDPRControl = "GDPRAccept";
    public static readonly string Haptic = "Haptic";
    public static readonly string IsFirstPlay = "IsFirstPlay";
    public static readonly string IntersititialWatchCount = "IntersititialWatchCount";
    //Rate Us
    public static readonly string RateUsHasSend = "RateUsHasSend";
    public static readonly string RateUs01HasShown = "RateUs01HasShown";
    public static readonly string RateUs02HasShown = "RateUs02HasShown";
    public static readonly string RateUs03HasShown = "RateUs03HasShown";
    //Daily Gift
    public static readonly string DailyLastRewardDay = "DailyLastRewardDay";
    public static readonly string DailyLastDayOfYear = "DailyLastDayOfYear";
    public static readonly string DailyStreak = "DailyStreak";
    public static readonly string DailyGiftFinishDateTime = "DailyGiftFinishDateTime";
    public static readonly string CurrentOfferFinishDateTime = "CurrentOfferFinishDateTime";
    public static readonly string NextOfferFinishDateTime = "NextOfferFinishDateTime";
    public static readonly string ActiveOfferIndexID = "ActiveOfferIndexID";
}
public static class PlayerPreferences
{
    public static bool IsFirstPlay
    {
        get => PlayerPrefs.GetInt(PlayerPrefKeys.IsFirstPlay, 0) == 1;
        set => PlayerPrefs.SetInt(PlayerPrefKeys.IsFirstPlay, value ? 1 : 0);
    }
    public static bool Haptic
    {
        get => PlayerPrefs.GetInt(PlayerPrefKeys.Haptic, 1) == 1;
        set => PlayerPrefs.SetInt(PlayerPrefKeys.Haptic, value ? 1 : 0);
    }
    public static bool RateUsHasSend
    {
        get => PlayerPrefs.GetInt(PlayerPrefKeys.RateUsHasSend, 0) == 1;
        set => PlayerPrefs.SetInt(PlayerPrefKeys.RateUsHasSend, value ? 1 : 0);
    }
    public static bool RateUs01HasShown
    {
        get => PlayerPrefs.GetInt(PlayerPrefKeys.RateUs01HasShown, 0) == 1;
        set => PlayerPrefs.SetInt(PlayerPrefKeys.RateUs01HasShown, value ? 1 : 0);
    }
    public static bool RateUs02HasShown
    {
        get => PlayerPrefs.GetInt(PlayerPrefKeys.RateUs02HasShown, 0) == 1;
        set => PlayerPrefs.SetInt(PlayerPrefKeys.RateUs02HasShown, value ? 1 : 0);
    }
    public static bool RateUs03HasShown
    {
        get => PlayerPrefs.GetInt(PlayerPrefKeys.RateUs03HasShown, 0) == 1;
        set => PlayerPrefs.SetInt(PlayerPrefKeys.RateUs03HasShown, value ? 1 : 0);
    }
    public static bool Sound
    {
        get => PlayerPrefs.GetInt(PlayerPrefKeys.Sound, 1) == 1;
        set => PlayerPrefs.SetInt(PlayerPrefKeys.Sound, value ? 1 : 0);
    }
    public static string DailyGiftFinishDateTime
    {
        get => PlayerPrefs.GetString(PlayerPrefKeys.DailyGiftFinishDateTime, string.Empty);
        set => PlayerPrefs.SetString(PlayerPrefKeys.DailyGiftFinishDateTime, value);
    }
    public static int ActiveOfferIndexID
    {
        get => PlayerPrefs.GetInt(PlayerPrefKeys.ActiveOfferIndexID, -1);
        set => PlayerPrefs.SetInt(PlayerPrefKeys.ActiveOfferIndexID, value);
    }
    public static string CurrentOfferFinishDateTime
    {
        get => PlayerPrefs.GetString(PlayerPrefKeys.CurrentOfferFinishDateTime, string.Empty);
        set => PlayerPrefs.SetString(PlayerPrefKeys.CurrentOfferFinishDateTime, value);
    }
    public static string NextOfferFinishDateTime
    {
        get => PlayerPrefs.GetString(PlayerPrefKeys.NextOfferFinishDateTime, string.Empty);
        set => PlayerPrefs.SetString(PlayerPrefKeys.NextOfferFinishDateTime, value);
    }
    public static int DailyStreak
    {
        get => PlayerPrefs.GetInt(PlayerPrefKeys.DailyStreak, 0);
        set => PlayerPrefs.SetInt(PlayerPrefKeys.DailyStreak, value);
    }
    public static int IntersititialWatchCount
    {
        get => PlayerPrefs.GetInt(PlayerPrefKeys.IntersititialWatchCount, 0);
        set => PlayerPrefs.SetInt(PlayerPrefKeys.IntersititialWatchCount, value);
    }
    public static int DailyLastDayOfYear
    {
        get => PlayerPrefs.GetInt(PlayerPrefKeys.DailyLastDayOfYear, 0);
        set => PlayerPrefs.SetInt(PlayerPrefKeys.DailyLastDayOfYear, value);
    }
    public static int DailyLastRewardDay
    {
        get => PlayerPrefs.GetInt(PlayerPrefKeys.DailyLastRewardDay, 0);
        set => PlayerPrefs.SetInt(PlayerPrefKeys.DailyLastRewardDay, value);
    }
}