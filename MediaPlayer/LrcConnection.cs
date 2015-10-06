using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaPlayer
{
    struct LrcConnection
    {
        public LrcConnection(int  lrcTime, string lrcText)
        {
            this.lrcTime = lrcTime;
            this.lrcText = lrcText;
        }
        private int lrcTime;

        public int LrcTime
        {
            get { return lrcTime; }
            set { lrcTime = value; }
        }
        private string lrcText;

        public string LrcText
        {
            get { return lrcText; }
            set { lrcText = value; }
        }
    }
}
