using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace s3auto.Controls
{
    public class WinS3DailyTask : S3Window
    {
        public WinS3DailyTask(Rectangle parent)
            : base(parent)
        {
            Name = "main/richang";
            //parentRect = parent;
            //Init();
        }

        public ButtonDailyTaskClass ButtonDailyTask
        {
            get
            {
                ButtonDailyTaskClass button = new ButtonDailyTaskClass(parentRect);
                button.Name = "";
                return button;
                //main/warn
            }
        }

        public ButtonArmageddonClass ButtonArmageddon
        {
            get
            {
                ButtonArmageddonClass button = new ButtonArmageddonClass(parentRect);
                button.Name = "";
                return button;
                //main/warn
            }
        }

        public ButtonDungeonClass ButtonDungeon
        {
            get
            {
                ButtonDungeonClass button = new ButtonDungeonClass(parentRect);
                button.Name = "";
                return button;
                //main/warn
            }
        }

        public ButtonTeamClass ButtonTeam
        {
            get
            {
                ButtonTeamClass button = new ButtonTeamClass(parentRect);
                button.Name = "";
                return button;
                //main/warn
            }
        }

        public ButtonCircleClass ButtonCircle
        {
            get
            {
                ButtonCircleClass button = new ButtonCircleClass(parentRect);
                button.Name = "";
                return button;
                //main/warn
            }
        }
    }
}
