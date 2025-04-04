namespace ContainerizedDB.API.Endpoints.Response
{
    public class ContainerViewModel
    {
        public required string ContainerId { get; set; }
        public required string ContainerImage { get; set; }
        public required int PortBinding { get; set; }
    }
}
