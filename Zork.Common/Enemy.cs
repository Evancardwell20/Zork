namespace Zork.Common
{
    public class Enemy
    {
        public string Name { get; }

        public string LookDescription { get; }

        public Enemy(string name, string lookDescription)
        {
            Name = name;
            LookDescription = lookDescription;
        }

        public override string ToString() => Name;
    }
}
