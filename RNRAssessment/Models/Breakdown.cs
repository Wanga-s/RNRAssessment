﻿namespace RNRAssessment.Models
{
    public class Breakdown
    {
        public int Id { get; set; }
        public string? BreakdownReference { get; set; }
        public string? CompanyName { get; set; }
        public string? DriverName { get; set; }
        public string? RegistrationNumber { get; set; }
        public DateTime BreakdownDate { get; set; }
    }
}
