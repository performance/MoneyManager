﻿using System.Collections.Generic;
using MoneyManager.Foundation.Model;
using MoneyManager.Foundation.OperationContracts;

namespace MoneyManager.Business.WindowsPhone.Test.Mocks {
    public class CategoryDataAccessMock : IDataAccess<Category> {
        public List<Category> CategoryTestList = new List<Category>();

        public void Save(Category itemToSave) {
            CategoryTestList.Add(itemToSave);
        }

        public void Delete(Category item) {
            if (CategoryTestList.Contains(item)) {
                CategoryTestList.Remove(item);
            }
        }

        public List<Category> LoadList() {
            return new List<Category>();
        }
    }
}