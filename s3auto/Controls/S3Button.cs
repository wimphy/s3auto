using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace s3auto.Controls
{
    public class S3Button : S3Window
    {
        private S3Button buttonWarning = null;

        public S3Button(Rectangle parent)
            : base(parent)
        {
            buttonWarning = new S3Button(parentRect);
            buttonWarning.Name = "main/warn";
        }

        public S3Button ButtonWarning
        {
            get
            {
                return buttonWarning;
            }
        }
    }

    public class ButtonDailyTaskClass : S3Window
    {
        public ButtonDailyTaskClass(Rectangle parent)
            : base(parent)
        {
        }
    }

    public class ButtonArmageddonClass : S3Window
    {
        private S3Button buttonArmageddonLatest = null;

        public ButtonArmageddonClass(Rectangle parent)
            : base(parent)
        {
            buttonArmageddonLatest = new S3Button(parentRect);
            buttonArmageddonLatest.Name = "";
        }

        public S3Button ButtonArmageddonLatest
        {
            get
            {
                return ButtonArmageddonLatest;
            }
        }
    }

    public class ButtonDungeonClass : S3Window
    {
        private S3Button buttonDungeonLatest = null;
        public ButtonDungeonClass(Rectangle parent)
            : base(parent)
        {
            buttonDungeonLatest = new S3Button(parentRect);
            buttonDungeonLatest.Name = "";
        }

        public S3Button ButtonDungeonLatest
        {
            get
            {
                return buttonDungeonLatest;
            }
        }
    }

    public class ButtonTeamClass : S3Window
    {
        public ButtonTeamClass(Rectangle parent)
            : base(parent)
        {
        }
    }

    public class ButtonCircleClass : S3Window
    {
        private S3Button buttonCircleLatest = null;

        public ButtonCircleClass(Rectangle parent)
            : base(parent)
        {
            buttonCircleLatest = new S3Button(parentRect);
            buttonCircleLatest.Name = "";
        }

        public S3Button ButtonCircleLatest
        {
            get
            {
                return buttonCircleLatest;
            }
        }
    }
}
