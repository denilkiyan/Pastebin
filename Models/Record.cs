namespace Pastbin.Models
{
    public class Record
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = "";

        public static Record CreateRecord(string text) 
        {
            Record record = new Record()
            {
                Id = Guid.NewGuid(),
                Text = text
            };
            return record;
        }
    }
}
