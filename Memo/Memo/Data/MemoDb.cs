using Memo.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Memo.Data
{
    public class MemoDb
    {
        readonly SQLiteAsyncConnection database;

        public MemoDb(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return database.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            return database.Table<Note>()
                            .Where(n => n.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.Id != 0)
            {
                return database.UpdateAsync(note);
            }

            return database.InsertAsync(note);
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return database.DeleteAsync(note);
        }
    }
}

