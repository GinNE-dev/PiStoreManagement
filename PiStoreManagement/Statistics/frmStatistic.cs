using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using PiStoreManagement.Managements;
using PiStoreManagement.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiStoreManagement.Statistics
{
    public partial class frmStatistic : Form
    {
        private string[] WEEK_DAY_CHART_LABLES = {  "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        private string[] MONTHS_CHART_LABLES  = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        
        public frmStatistic()
        {
            InitializeComponent();
        }

        private DataPoint FindPeakDataPoint(List<DataPoint> points)
        {
            DataPoint peakPoint = points.First();
            
            foreach(DataPoint p in points)
            {
                peakPoint = p.Y > peakPoint.Y ? p : peakPoint;
            }

            return peakPoint;
        }

        private void PrepareWeekLable(CategoryAxis xAxis)
        {
            foreach (string lb in WEEK_DAY_CHART_LABLES)
            {
                xAxis.Labels.Add(lb);
            }
        }

        private void PrepareYearLable(CategoryAxis xAxis)
        {
            foreach (string lb in MONTHS_CHART_LABLES)
            {
                xAxis.Labels.Add(lb);
            }
        }

        public void DrawChartByPeriod()
        {
            DateTime selectedDate = dateTimePickerRange.Value;
            DateTime dayStart;  

            var dataPoints = new List<DataPoint>();
            List<Order> orders;

            CategoryAxis xAxis = new CategoryAxis();
            string title = "Shop Revenue over a " + comboBoxPeriod.Text.ToLower();
            double revenue = 0;
            switch (comboBoxPeriod.Text.ToString().ToLower())
            {
                case "week":
                   dayStart  = selectedDate.AddDays(-(int)selectedDate.DayOfWeek + 1);
                    title += " (" + dayStart.ToString("MM/dd/yyy")+ "-";
                    for (int i = 0; i<7; i++)
                    {
                        orders = ShopDB.GetShopDBEntities().Orders.Where(
                            o => o.OrderDate.Value.Year.Equals(dayStart.Year)
                            && o.OrderDate.Value.Month.Equals(dayStart.Month)
                            && o.OrderDate.Value.Day.Equals(dayStart.Day)
                            ).ToList();

                        revenue = 0;
                        foreach (Order order in orders)
                        {
                            revenue += order.TotalPrice;
                        }

                        dataPoints.Add(new DataPoint(i, revenue));
                        dayStart = dayStart.AddDays(1);
                    }
                    title +=  dayStart.AddDays(-1).ToString("MM/dd/yyy") + ")";
                    //xAxis = _weekDayXAxis;

                    PrepareWeekLable(xAxis);
                    break;
                case "month":
                    dayStart = selectedDate.AddDays(-(int)selectedDate.Day + 1);
                    
                    for (int i = 1; i <= DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month); i++)
                    {
                        orders = ShopDB.GetShopDBEntities().Orders.Where(
                            o => o.OrderDate.Value.Year.Equals(dayStart.Year)
                            && o.OrderDate.Value.Month.Equals(dayStart.Month)
                            && o.OrderDate.Value.Day.Equals(dayStart.Day)
                            ).ToList();

                        revenue = 0;
                        foreach (Order order in orders)
                        {
                            
                            revenue += order.TotalPrice;
                        }

                        dataPoints.Add(new DataPoint(i, revenue));
                        dayStart = dayStart.AddDays(1);
                    }

                    title += " ("+selectedDate.Month.ToString()+"/"+selectedDate.Year+")";
                    break;

                case "year":

                    orders = ShopDB.GetShopDBEntities().Orders.Where(
                            o => o.OrderDate.Value.Year.Equals(selectedDate.Year)
                            ).ToList();
                            
                    for (int i = 1; i <= 12; i++)
                    {
                        orders = ShopDB.GetShopDBEntities().Orders.Where(
                            o => o.OrderDate.Value.Year.Equals(selectedDate.Year)
                            && o.OrderDate.Value.Month.Equals(i)
                            ).ToList();

                        revenue = 0;
                        foreach (Order order in orders)
                        {

                            revenue += order.TotalPrice;
                        }

                        dataPoints.Add(new DataPoint(i, revenue));
                    }
                    title += " ("+ selectedDate.Year + ")";
                    PrepareYearLable(xAxis);
                    break;
                default:

                    break;
            }

            var lineSeries = new LineSeries
            {
                ItemsSource = dataPoints,
                Title = "Shop Revenue"
            };

            var plotModel = new PlotModel()
            {
                Title = title
            };

            var _yAxis = new LinearAxis()
            {
                Minimum = 0,
                Maximum = FindPeakDataPoint(dataPoints).Y,
                Title = "Revenue"
            };

            plotModel.Axes.Add(_yAxis);
            
            if(!comboBoxPeriod.Text.ToLower().Equals("month"))
            {
                plotModel.Axes.Add(xAxis);
            }
            
            plotModel.Series.Add(lineSeries);

            plotViewMain.Model = plotModel;
        }

        private void comboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawChartByPeriod();
        }

        private void dateTimePickerRange_ValueChanged(object sender, EventArgs e)
        {
            DrawChartByPeriod();
        }

        private void btnGenerateBillForTest_Click(object sender, EventArgs e)
        {
            TestingTool.GenerateRandomOrderForTest();
        }

        private void frmStatistic_Load(object sender, EventArgs e)
        {
            DrawChartByPeriod();
        }

        private void btnGeneareDataTest_Click(object sender, EventArgs e)
        {
            TestingTool.GenerateRandomOrderForTest();
        }
    }
}
