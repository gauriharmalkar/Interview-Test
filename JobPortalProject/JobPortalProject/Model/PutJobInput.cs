﻿namespace JobPortalProject.Model
{
    public class PutJobInput
    {
        public string title { get; set; }
        public string description { get; set; }
        public int locatioId { get; set; }
        public int departmentId { get; set; }
        public DateTime closingDate { get; set; }
    }
}
