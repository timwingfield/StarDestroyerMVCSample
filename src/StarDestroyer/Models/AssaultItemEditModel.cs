namespace StarDestroyer.Models
{
    public class AssaultItemEditModel
    {
        public virtual int Id { get; set; }
        public virtual string Type { get; set; }
        public virtual string Description { get; set; }
        public virtual int LoadValue { get; set; }   
    }
}