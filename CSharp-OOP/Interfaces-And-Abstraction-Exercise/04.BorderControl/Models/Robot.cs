using _04.BorderControl.Models.Contracts;

namespace _04.BorderControl.Models
{
    public class Robot : IId
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }

        public string Id { get; set; }
    }
}
