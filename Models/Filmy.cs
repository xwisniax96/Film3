
namespace Film3.Models
{
    public class Filmy
    {
        public int id { get; set; }
        public int Id { get; internal set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }

        internal Filmy FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
