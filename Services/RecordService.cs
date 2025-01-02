using Microsoft.EntityFrameworkCore;
using Pastbin.DBContext;
using Pastbin.Interfaces;
using Pastbin.Models;

namespace Pastbin.Services
{
    public class RecordService:IRecordService
    {
        private readonly PastebinContext _context;
        public RecordService(PastebinContext context)
        {
            _context = context;
        }

        public async Task<string> CreateRecord(string text)
        {
            Record record = Record.CreateRecord(text);
            await _context.Records.AddAsync(record);
            await _context.SaveChangesAsync();
            return record.Id.ToString();
        }
        public async Task<bool> DeleteRecord(Guid id)
        {
            Record record = await _context.Records.FirstOrDefaultAsync(i => i.Id == id);
            if (record != null)
            {
                _context.Remove(record);
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<Record> FindRecordFromId(string id)
        {
            Guid guid = Guid.Parse(id);
            var rec = await _context.Records.FirstOrDefaultAsync(i => i.Id == guid);
            return rec;
        }
    }
}
