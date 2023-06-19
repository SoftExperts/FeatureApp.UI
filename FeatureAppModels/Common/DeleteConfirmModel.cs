namespace Models.Common
{
    public class DeleteConfirmModel
    {
        public Guid? IdToDelete { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
