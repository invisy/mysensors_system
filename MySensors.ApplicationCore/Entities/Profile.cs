namespace MySensors.ApplicationCore.Entities
{
    public class Profile : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
    }
}