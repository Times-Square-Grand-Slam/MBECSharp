using System;
using System.Globalization;
using System.Windows.Forms;

namespace MBECSharp
{
    public partial class CalendarView : Form
    {
        public CalendarView()
        {
            InitializeComponent();
        }

        private void CalendarView_Load(object sender, System.EventArgs e)
        {
            //Get today's date
            DateTime now = DateTime.Today;
            int mth = now.Month;
            int yr = now.Year;

            //Populate comboboxes
            cbMonth.Text = now.ToString("MMMM");
            cbYear.Text = now.Year.ToString();

            //Populate calendar
            popCalendar();
        }

        private void popCalendar()
        {
            //Create new variable and pull month and year from combo boxes
            int yr = Convert.ToInt32(cbYear.Text);
            int mth = DateTime.ParseExact(cbMonth.Text, "MMMM", CultureInfo.CurrentCulture).Month;
            DateTime fom = new DateTime(yr, mth, 1);
            int cnt = 0;
            string lbname;
            ListBox ctn;

            if (fom.DayOfWeek == DayOfWeek.Sunday)
            {
                cnt = -7;
            }


            //Add dates to list boxes
            for (int i = 0; i <= 41; i++)
            {
                lbname = "lb" + i;
                ctn = (ListBox)this.Controls.Find(lbname, true)[0];

                ctn.Items.Add(fom.AddDays(cnt - (int)fom.DayOfWeek+1).Day).ToString();
                if (fom.AddDays(cnt - (int)fom.DayOfWeek+1).Month != mth)
                {
                    ctn.ForeColor = System.Drawing.Color.DimGray;
                }

                if (fom.AddDays(cnt - (int)fom.DayOfWeek+1) == DateTime.Today)
                {
                    ctn.BackColor = System.Drawing.Color.Azure;
                }
                cnt++;
            }
        }

        private void clearCalendar()
        {
            ListBox ctn;
            string lbname;

            //Add dates to list boxes
            for (int i = 0; i <= 41; i++)
            {
                lbname = "lb" + i;
                ctn = (ListBox)this.Controls.Find(lbname, true)[0];

                ctn.Items.Clear();
                ctn.ForeColor = System.Drawing.Color.Black;
                ctn.BackColor = System.Drawing.Color.White;

            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int yr = Convert.ToInt32(cbYear.Text);
            int mth = DateTime.ParseExact(cbMonth.Text, "MMMM", CultureInfo.CurrentCulture).Month;
            DateTime fom = new DateTime(yr, mth, 1);

            fom = fom.AddMonths(1);

            //Populate comboboxes
            cbMonth.Text = fom.ToString("MMMM");
            cbYear.Text = fom.Year.ToString();

            //Clear the listboxs
            clearCalendar();

            //Repopulate the listboxes
            popCalendar();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            int yr = Convert.ToInt32(cbYear.Text);
            int mth = DateTime.ParseExact(cbMonth.Text, "MMMM", CultureInfo.CurrentCulture).Month;
            DateTime fom = new DateTime(yr, mth, 1);

            fom = fom.AddMonths(-1);

            //Populate comboboxes
            cbMonth.Text = fom.ToString("MMMM");
            cbYear.Text = fom.Year.ToString();

            //Clear the listboxs
            clearCalendar();

            //Repopulate the listboxes
            popCalendar();
        }
    }
}
