﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ResponeModel
    {
        public string Text { get; set; }

        public dynamic intentions { get; set; }

        public long GetAudioTextLantency { get; set; }

        public long GetAudioIntentionLantency { get; set; }

        public int StatusCode { get; set; }

        public string StatusMessage { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
