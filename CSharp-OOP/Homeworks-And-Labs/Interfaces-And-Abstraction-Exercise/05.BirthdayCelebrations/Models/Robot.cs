using _05.BirthdayCelebrations;

namespace _05.BirthdayCelebrations
{
    public class Robot : Identifiable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }

        public string Id { get; private set; }
    }
}
