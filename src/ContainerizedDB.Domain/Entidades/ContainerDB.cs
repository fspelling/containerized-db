namespace ContainerizedDB.Domain.Entidades
{
    public class ContainerDB
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Image { get; set; }
        public required int PortBinding { get; set; }
    }
}
