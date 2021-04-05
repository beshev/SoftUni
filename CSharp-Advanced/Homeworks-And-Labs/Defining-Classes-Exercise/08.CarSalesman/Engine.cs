namespace DefiningClasses
{
    public class Engine
    {

        public Engine(string model, string power)
        {
            Model = model;
            Power = power;
            Displacement = "n/a";
            Efficiency = "n/a";
        }

        public Engine(string model, string power, string displacement, string efficiency) : this(model, power)
        {
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }

        public string Power { get; set; }

        public string Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            return $"  {Model}:\n" +
                $"    Power: {Power}\n" +
                $"    Displacement: {Displacement}\n" +
                $"    Efficiency: {Efficiency}";
        }
    }
}
