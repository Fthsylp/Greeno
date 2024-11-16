namespace Greeno.Models.Domain
{
    public class About
    {
        public Guid Id { get; set; }

        public string Title {get; set;}

        public string Description {get; set;}

        public int Satisfaction {get; set;}

        public int FreeDelivery {get; set;}

        public int StoreLocators { get; set;}
    }
}
