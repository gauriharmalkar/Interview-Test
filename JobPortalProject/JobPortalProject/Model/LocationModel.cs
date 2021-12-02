namespace JobPortalProject.Model
{
    public class locationModel 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Zip { get; set; }




    }
    public class LocationSaveModel
    {
        public int Id { get; set; }
    }

    public class CreateLocationInput
    {
        public string Title { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Zip { get; set; }
    }

    public class PutLocationInput
    {
        public string Title { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Zip { get; set; }
    }
}
