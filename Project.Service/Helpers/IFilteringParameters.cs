﻿namespace Project.Service.Helpers
{
    public interface IFilteringParameters
    {
        public string CurrentFilter { get; set; }
        public string FilterString { get; set; }
    }
}