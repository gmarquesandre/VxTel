﻿using VxTel.Shared.Models;

namespace VxTel.Shared.Dto
{
    public class CallPlanDto
    {
        public string Name { get; set; }
        public int FreeTime { get; set; }
        public double ExcedeedTimeFeePercentage { get; set; }      

    }
}