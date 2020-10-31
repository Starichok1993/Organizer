namespace Organizer.Web.Models
{
    public class UpdateToDoRequest
    {       
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
