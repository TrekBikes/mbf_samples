using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.FormFlow;

namespace Bot_Application1.Forms
{
    [Serializable]
    public class AgeAndLocation
    {
        public int Age;
        public string Location;

        public static IForm<AgeAndLocation> BuildForm()
        {
            return new FormBuilder<AgeAndLocation>()
                    .Message("Welcome to the age and location doodad!")
                    .Build();
        }
    }
}