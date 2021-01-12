using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class ListViewSwipingViewModel
    {
        #region Fields

        private ObservableCollection<ListViewInboxInfo> inboxInfo;
        #endregion

        #region Constructor

        public ListViewSwipingViewModel()
        {
            SetFavoriteCommand = new Command<object>(SetFavorites);
            GenerateSource();
        }
        #endregion

        #region Properties

        public ObservableCollection<ListViewInboxInfo> InboxInfo
        {
            get { return inboxInfo; }
            set { this.inboxInfo = value; }
        }

        public Command<object> SetFavoriteCommand { get; set; }
        #endregion

        #region Methods

        private void GenerateSource()
        {
            ListViewInboxInfoRepository inboxinfo = new ListViewInboxInfoRepository();
            inboxInfo = inboxinfo.GetInboxInfo();
        }

        private void SetFavorites(object obj)
        {
            var customCommandParameter = obj as CustomCommandParameter;
            (customCommandParameter.CommandParameter as ListViewInboxInfo).IsFavorite = !(customCommandParameter.CommandParameter as ListViewInboxInfo).IsFavorite;
            customCommandParameter.ListView.ResetSwipe();
        }
        #endregion
    }
}
