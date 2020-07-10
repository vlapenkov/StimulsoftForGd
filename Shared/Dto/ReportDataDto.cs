namespace Shared.Dto
{
    public class ReportDataDto
    {
        public string Id { get; set; }

        public byte[] FileBody { get; set; }

        public string ReportSettingsId { get; set; }
    }
}