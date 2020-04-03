using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAD : MonoBehaviour
{
    // Start is called before the first frame update
    public static DontDestroyAD instance;
    private RewardedAd rewarded;
    public bool restart;
    string adCode = "ca - app - pub - 6638560950207737 / 5615016813";
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    public void loadAD()
    {
        this.rewarded = new RewardedAd(adCode);

        this.rewarded.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewarded.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewarded.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewarded.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewarded.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewarded.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.rewarded.LoadAd(request);
    }
    public void showAD()
    {
        this.rewarded.Show();   
    }
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        restart = true;
    }
    public void UserChoseToWatchAd()
    {
        this.rewarded.Show();
    }
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }
}
