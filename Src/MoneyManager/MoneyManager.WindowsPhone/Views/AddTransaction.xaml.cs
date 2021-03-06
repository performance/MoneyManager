﻿#region

using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.ServiceLocation;
using MoneyManager.Business.ViewModels;
using MoneyManager.Common;
using MoneyManager.Foundation;

#endregion

namespace MoneyManager.Views {
    public sealed partial class AddTransaction {
        private readonly NavigationHelper navigationHelper;

        public AddTransaction() {
            InitializeComponent();
            navigationHelper = new NavigationHelper(this);
        }

        private AddTransactionViewModel AddTransactionView {
            get { return ServiceLocator.Current.GetInstance<AddTransactionViewModel>(); }
        }

        public NavigationHelper NavigationHelper {
            get { return navigationHelper; }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            if (e.NavigationMode != NavigationMode.Back && AddTransactionView.IsEdit) {
                //TODO:Refactor
                //await AccountLogic.RemoveTransactionAmount(AddTransactionView.SelectedTransaction);
            }

            base.OnNavigatedTo(e);
        }

        private void DoneClick(object sender, RoutedEventArgs e) {
            //TODO:Refactor
            //if (AddTransactionView.SelectedTransaction.ChargedAccount == null) {
            //    ShowAccountRequiredMessage();
            //    return;
            //}

            AddTransactionView.Save();
        }

        private async void ShowAccountRequiredMessage() {
            var dialog = new MessageDialog
                (
                Translation.GetTranslation("AccountRequiredMessage"),
                Translation.GetTranslation("MandatoryField")
                );
            dialog.Commands.Add(new UICommand(Translation.GetTranslation("OkLabel")));
            dialog.DefaultCommandIndex = 1;
            await dialog.ShowAsync();
        }

        private void CancelClick(object sender, RoutedEventArgs e) {
            AddTransactionView.Cancel();
        }
    }
}