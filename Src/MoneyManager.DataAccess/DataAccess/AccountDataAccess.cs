﻿using System.Collections.Generic;
using System.Linq;
using MoneyManager.Foundation;
using MoneyManager.Foundation.Model;
using PropertyChanged;
using SQLiteNetExtensions.Extensions;

namespace MoneyManager.DataAccess.DataAccess {
    [ImplementPropertyChanged]
    public class AccountDataAccess : AbstractDataAccess<Account> {
        protected override void SaveToDb(Account itemToSave) {
            using (var db = SqlConnectionFactory.GetSqlConnection()) {
                if (itemToSave.Id == 0) {
                    db.InsertWithChildren(itemToSave);
                }
                else {
                    db.UpdateWithChildren(itemToSave);
                }
            }
        }

        protected override void DeleteFromDatabase(Account itemToDelete) {
            using (var db = SqlConnectionFactory.GetSqlConnection()) {
                db.Delete(itemToDelete);
            }
        }

        protected override List<Account> GetListFromDb() {
            using (var db = SqlConnectionFactory.GetSqlConnection()) {
                return db.Table<Account>()
                    .OrderBy(x => x.Name)
                    .ToList();
            }
        }
    }
}