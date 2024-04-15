﻿namespace Ekklesia.Entities.Filters
{
    public class FilterRule
    {
        public FilterType Type { get; set; }
        public string Field { get; set; }
        public string Arg { get; set; }

        public FilterRule()
        {
            this.Field = string.Empty;
            this.Arg = string.Empty;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
