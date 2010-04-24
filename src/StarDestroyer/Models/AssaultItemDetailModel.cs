using System.Collections.Generic;

namespace StarDestroyer.Models
{
    public class AssaultItemDetailModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int LoadValue { get; set; }
        public List<string> Images { get; set; }
    }
}