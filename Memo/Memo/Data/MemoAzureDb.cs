using Memo.Common;
using Memo.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo.Data
{
    public class MemoAzureDb
    {
        private MobileServiceClient mobileService;

        public MemoAzureDb()
        {
            this.mobileService = new MobileServiceClient(AppConst.AzureWebApp);
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return this.mobileService.GetTable<Note>().ToListAsync();
        }

        public async Task<Note> GetNote(string id)
        {
            var notes = await this.mobileService.GetTable<Note>()
                            .Where(n => n.Id == id)
                            .ToListAsync();

            return notes.FirstOrDefault();
        }

        public async void SaveNoteAsync(Note note)
        {
            if (note.Id != null)
            {
                await this.mobileService.GetTable<Note>().UpdateAsync(note);
                return;
            }

            await this.mobileService.GetTable<Note>().InsertAsync(note);
        }

        public async void DeleteNoteAsync(Note note)
        {
            await this.mobileService.GetTable<Note>().DeleteAsync(note);
        }

        public async Task<User> GetUser(string email, string password)
        {
            var users = await this.mobileService.GetTable<User>()
                                    .Where(u => u.Email == email)
                                    .ToListAsync();

            if (users.Count > 1)
            {
                throw new DataMisalignedException();
            }

            var user = users.FirstOrDefault(u => CryptoService.IsValidPassword(password, u.Password));

            return user;
        }

        public async void InsertUser(User user)
        {
            await this.mobileService.GetTable<User>().InsertAsync(user);                                    
        }
    }
}
