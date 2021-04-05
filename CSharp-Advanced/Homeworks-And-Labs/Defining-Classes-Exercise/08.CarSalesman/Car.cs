namespace DefiningClasses
{
    public class Car
    {
        public Car(string model,Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = "n/a";
            Color = "n/a";
        }

        public Car(string model, Engine engine,string weight,string color) : this(model,engine)
        {
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public string Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            return $"{Model}:\n" +
                $"{Engine}\n" +
                $"   Weight: {Weight}\n" +
                $"   Color: {Color}";
        }
    }
}