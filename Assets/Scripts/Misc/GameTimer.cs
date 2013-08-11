using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Misc
{
    public class GameTimer : MonoBehaviour
    {        
        public double totalGameSeconds;

        public double seconds;
        public double minutes;
        public double hours;
        public double days;
        public double months;
        public double years;

        private double secondsPerSecond;
        private DateTime dt;

        private void Start()
        {
            secondsPerSecond = 180;
            totalGameSeconds = 21600;
        }

        public string GameTime
        {
            get
            {
                //return "00:00";
                return (hours % 24).ToString("00") + ":" + (minutes % 60).ToString("00");
            }
        }


        private void Update()
        {

            totalGameSeconds += secondsPerSecond*Time.deltaTime;

            seconds = totalGameSeconds;
            minutes = totalGameSeconds/60;
            hours = minutes/60;
            days = hours/24;
            months = days/(365/12);
            years = months/12;
        }
    }
}
