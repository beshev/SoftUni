namespace _07.MilitaryElite.Models.Contracts
{
    public class Repair 
    {
        public Repair(string part,int hours)
        {
            this.Part = part;
            this.Hours = hours;
        }

        public string Part { get; set; }

        public int Hours { get; set; }

        public override string ToString()
        {
            return $"Part Name: {this.Part} Hours Worked: {this.Hours}";
        }
    }
}