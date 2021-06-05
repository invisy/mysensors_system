namespace MySensors.ApplicationCore.Interfaces
{
    public interface ISensorTokenGenerator
    {
        public string GenerateRandomUniqueToken();
    }
}