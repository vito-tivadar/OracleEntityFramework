namespace OracleEntityFramework
{
    public class AAAAttribute : Attribute
    {
        public string Description { get; set; }
        public AAAAttribute(string description)
        {
            Description = description;
        }
    }
}
