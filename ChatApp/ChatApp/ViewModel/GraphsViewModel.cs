using ChatApp.HelperClasses;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ChatApp.ViewModel
{
    public class GraphsViewModel : BaseViewModel
    {
        public ObservableCollection<Tuple<string, int>> GraphData { get; set; }

        private SeriesCollection seriesCollection { get; set; }
        public SeriesCollection SeriesCollection
        {
            get { return seriesCollection; }
            set { seriesCollection = value; SendPropertyChanged(nameof(SeriesCollection)); }
        }
        public GraphsViewModel()
        {
            Init();
        }

        public void Init()
        {
            GetGraphData();
        }

        private void GetGraphData()
        {
            ClientHelper.SendMessage(MessageHandleEnum.GRAPHDATA, "");
            SeriesCollection = new SeriesCollection();
            var listGraphData = ClientHelper.GraphData;
            foreach (var element in listGraphData)
            {
                var pieSeries = new PieSeries
                {
                    Title = element.Item1,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(element.Item2) },
                    DataLabels = true
                };
                SeriesCollection.Add(pieSeries);
            }
            SendPropertyChanged(nameof(SeriesCollection));
        }
    }
}