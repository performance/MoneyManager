using MoneyManager.Src;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using Windows.Storage;

namespace MoneyManager.DataAccess
{
    public class SettingDataAccess : INotifyPropertyChanged
    {
        private const string DbVersionKeyname = "DbVersion";
        private const string CurrencyKeyname = "Currency";

        private const int DbVersionKeydefault = 1;
        private const string CurrencyKeydefault = "CHF";

        #region Properties

        public int Dbversion
        {
            get
            {
                return GetValueOrDefault(DbVersionKeyname, DbVersionKeydefault);
            }
            set
            {
                AddOrUpdateValue(DbVersionKeyname, value);
                OnPropertyChanged();
            }
        }

        public string Currency
        {
            get
            {
                return GetValueOrDefault(CurrencyKeyname, CurrencyKeydefault);
            }
            set
            {
                AddOrUpdateValue(CurrencyKeyname, value);
                OnPropertyChanged();
            }
        }

        #endregion Properties

        private void AddOrUpdateValue(string key, object value)
        {
            ApplicationData.Current.RoamingSettings.Values[key] = value;
        }

        private valueType GetValueOrDefault<valueType>(string key, valueType defaultValue)
        {
            valueType value;

            if (ApplicationData.Current.RoamingSettings.Values.ContainsKey(key))
            {
                var setting = ApplicationData.Current.RoamingSettings.Values[key];
                value = (valueType)Convert.ChangeType(setting, typeof(valueType), CultureInfo.InvariantCulture);
            }
            else
            {
                value = defaultValue;
            }
            return value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}