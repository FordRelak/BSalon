namespace BSalonWebApp.Models.SalonServices
{
    public abstract class Service
    {
        public int Id { get; set; }

        public uint Price { get; set; }

        public string Title { get; set; }
    }
}
