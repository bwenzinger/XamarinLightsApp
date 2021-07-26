using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace App1.Models
{
    public class MainPageViewModel : BaseModel
    {
        private MainPageModel _mainPageModel;

        public MainPageViewModel()
        {
            _mainPageModel = new MainPageModel();
        }

        public bool IsLoadingLightStatus
        {
            get { return _mainPageModel.lightStatusOn == null ? true : false; }
            //get
            //{
            //    return true;
            //}
        }

        public bool LightStatusOn
        {
            get { return (bool)((_mainPageModel.lightStatusOn != null) ? _mainPageModel.lightStatusOn : false); }
            set
            {
                _mainPageModel.lightStatusOn = value;
                OnPropertyChanged("LightStatusOn");
                OnPropertyChanged("LightStatusOff");
                OnPropertyChanged("IsLoadingLightStatus");
            }
        }
        public bool LightStatusOff
        {
            get { return (bool)((_mainPageModel.lightStatusOn != null) ? !_mainPageModel.lightStatusOn : false); }
        }
    }
}
