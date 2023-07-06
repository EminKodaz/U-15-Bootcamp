using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
    [SerializeField] private float timeMultiplier, startHour,sunriseHour,sunseHour,maxSunLightInsentitiy,maxMoonlightInsentitiy;
    [SerializeField] private Text timeText;
    [SerializeField] private Light sunLight,moonLight;
    [SerializeField] private Color dayAmbientLight, nightAmbientLight;
    [SerializeField] private AnimationCurve LightChangeCurve;

    private DateTime currentTime;
    private TimeSpan sunriseTime,sunsetTime;

    private void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);

        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunseHour);
    }

    private void Update()
    {
        UpdateTimeOfDay();
        RotaeSun();
        UpdateLightSettings();
    }

    private void UpdateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);

        if (timeText != null)
        {
            timeText.text = currentTime.ToString("HH:mm");
        }
    }

    private void RotaeSun()
    {
        float sunLightRotation;

        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            TimeSpan SunriseToSunsetDuyration = CalculateTimeDifference(sunriseTime , sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / SunriseToSunsetDuyration.TotalMinutes;
            sunLightRotation = Mathf.Lerp(0,100,(float)percentage);
        }

        else
        {
            TimeSpan SunrsetToSunriseDuyration = CalculateTimeDifference(sunsetTime, sunriseTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / SunrsetToSunriseDuyration.TotalMinutes;
            sunLightRotation = Mathf.Lerp(100, 360, (float)percentage);
        }

        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation,Vector3.right);
    }

    private void UpdateLightSettings()
    {
        float dotProduct = Vector3.Dot(sunLight.transform.forward, Vector3.down);
        sunLight.intensity = Mathf.Lerp(0, maxSunLightInsentitiy, LightChangeCurve.Evaluate(dotProduct));
        moonLight.intensity = Mathf.Lerp(maxMoonlightInsentitiy, 0, LightChangeCurve.Evaluate(dotProduct));
        RenderSettings.ambientLight = Color.Lerp(nightAmbientLight, dayAmbientLight, LightChangeCurve.Evaluate(dotProduct));
    }

    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;

        if (difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }
}
