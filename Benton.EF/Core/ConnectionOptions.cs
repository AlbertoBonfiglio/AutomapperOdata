namespace Benton.EF.Core
{
    public class ConnectionOptions
    {
        public bool Encrypted {get; set;}
        public string CONN { get; set; }
        public bool DropDatabase {get; set;}
        public bool SeedDatabase{get; set;}
    }
}
