using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedPageDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTabbedPage : TabbedPage
    {
        
        public MyTabbedPage ()
        {
            InitializeComponent();

            BindingContext = new CurrentStatusDeviceViewModel();
        }
    }

    public class CurrentStatusDeviceViewModel
    {
        public ObservableCollection<TabViewModel> Things { set; get; }

        public CurrentStatusDeviceViewModel()
        {
            Things = new ObservableCollection<TabViewModel>();
            for (int i=0; i<3; i++)
            {
                Things.Add(new TabViewModel(i.ToString()) { description = "description" + i });
            }
        }
    }

    public class TabViewModel
    {
        public string description { set; get; }

        public string TabID { set; get; }

        public CurrentStatusDeviceDetailedViewModel DetailedViewModel { set; get; }

        public TabViewModel(string tabID)
        {
            TabID = tabID;
            DetailedViewModel = new CurrentStatusDeviceDetailedViewModel(tabID);
        }
    }

    public class CurrentStatusDeviceDetailedViewModel
    {
        public ObservableCollection<SensorModel> Sensors { set; get; }
        public string CurrentID { set; get; }

        public CurrentStatusDeviceDetailedViewModel(string tabId)
        {
            CurrentID = tabId;

            Sensors = new ObservableCollection<SensorModel>();
            for (int i=0; i<10; i++)
            {
                Sensors.Add(new SensorModel { idKeyDataParameter = "TabId:" + CurrentID + "\n" + "ListID" + i });
            }
        }
    }

    public class SensorModel
    {
        public string idKeyDataParameter { set; get; }
    }
}