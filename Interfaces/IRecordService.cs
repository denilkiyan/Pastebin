using Pastbin.Models;

namespace Pastbin.Interfaces
{
    public interface IRecordService
    {
        public Task<string> CreateRecord(string text);

        public Task<bool> DeleteRecord(Guid id);

        public Task<Record> FindRecordFromId(string id);
    }
}
