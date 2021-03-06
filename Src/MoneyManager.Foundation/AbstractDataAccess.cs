﻿using System;
using System.Collections.Generic;
using MoneyManager.Foundation.OperationContracts;
using Xamarin;

namespace MoneyManager.Foundation {
    public abstract class AbstractDataAccess<T> : IDataAccess<T> {
        /// <summary>
        ///     Will insert the item to the database if not exists, otherwise will
        ///     update the existing
        /// </summary>
        /// <param name="itemToSave">item to save.</param>
        public void Save(T itemToSave) {
            try {
                SaveToDb(itemToSave);
            }
            catch (Exception ex) {
                InsightHelper.Report(ex);
            }
        }

        /// <summary>
        ///     Deletes the passed item from the database
        /// </summary>
        /// <param name="itemToDelete">Item to delete.</param>
        public void Delete(T itemToDelete) {
            try {
                DeleteFromDatabase(itemToDelete);
            }
            catch (Exception ex) {
                InsightHelper.Report(ex);
            }
        }

        /// <summary>
        ///     Loads all medicines and returns a list
        /// </summary>
        /// <returns>The list from db.</returns>
        public List<T> LoadList() {
            try {
                return GetListFromDb();
            }
            catch (Exception ex) {
                InsightHelper.Report(ex);
            }
            return new List<T>();
        }

        protected abstract void SaveToDb(T itemToAdd);
        protected abstract void DeleteFromDatabase(T itemToDelete);
        protected abstract List<T> GetListFromDb();
    }
}