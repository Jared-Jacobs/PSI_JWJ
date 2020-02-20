using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace PP2_JWJ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculatePush(object sender, RoutedEventArgs e)
        {
            String sex = "";
            double PSI = 0;
            int nursingHome = 0;
            int neoplastic = 0;
            int liverDisease = 0;
            int heartFailure = 0;
            int cerebroDisease = 0;
            int renalDisease = 0;
            int alteredMentalStatus = 0;
            int pleuralEffusion = 0;
            double BUN = 0;
            double glucose = 0;
            double oxygenPressure = 0;
            double temp = 0;

            //Checking to see what boxes are checked, if checked then set 1 for YES for later output and then add the said amount of points in specifications to PSI
            //Also have else statements incase you want to enter multiple clients into the program without having to restart the program each time
            if (chkLiver.IsChecked == true)
            {
                liverDisease = 1;
                PSI = PSI + 20;
            }
            else
            {
                liverDisease = 0;
            }

            if (chkMentalStatus.IsChecked == true)
            {
                alteredMentalStatus = 1;
                PSI = PSI + 20;
            }
            else
            {
                alteredMentalStatus = 0;
            }

            if (chkCerebro.IsChecked == true)
            {
                cerebroDisease = 1;
                PSI = PSI + 10;
            }
            else
            {
                cerebroDisease = 0;
            }

            if (chkNeoplastic.IsChecked == true)
            {
                neoplastic = 1;
                PSI = PSI + 30;
            }
            else
            {
                neoplastic= 0;
            }

            if (chkPleural.IsChecked == true)
            {
                pleuralEffusion = 1;
                PSI = PSI + 10;
            }
            else
            {
                pleuralEffusion = 0;
            }

            if (chkNursing.IsChecked == true)
            {
                nursingHome = 1;
                PSI = PSI + 10;
            }
            else
            {
                nursingHome = 0;
            }

            if (chkRenal.IsChecked == true)
            {
                renalDisease = 1;
                PSI = PSI + 10;
            }
            else
            {
                renalDisease = 0;
            }

            if (chkHeartFailure.IsChecked == true)
            {
                heartFailure = 1;
                PSI = PSI + 10;
            }
            else
            {
                heartFailure = 0;
            }

            if (rdoFemale.IsChecked == true)
            {
                PSI -= 10;
                sex = "F";
            }

            else if (rdoMale.IsChecked == true)
            {
                sex = "M";
            }
            else
            {
                MessageBox.Show("Please choose a sex", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            if (txtAge.Text != "")
            {
                PSI = PSI + Convert.ToDouble(txtAge.Text);
            }

            if (txtRespRate.Text != "")
            {
                if (Convert.ToDouble(txtBloodPressure.Text) >= 30)
                {
                    PSI = PSI + 20;
                }
            }

            if (txtPulse.Text != "")
            {
                if (Convert.ToDouble(txtPulse.Text) >= 125)
                {
                    PSI = PSI + 10;
                }
            }

            if (txtPH.Text != "")
            {
                if (Convert.ToDouble(txtPH.Text) < 7.35)
                {
                    PSI = PSI + 30;
                }
            }

            if (txtBloodPressure.Text != "")
            {
                if (Convert.ToDouble(txtBloodPressure.Text) < 90)
                {
                    PSI = PSI + 20;
                }
            }

            if (txtSodium.Text != "")
            {
                if (Convert.ToDouble(txtSodium.Text) < 130)
                {
                    PSI = PSI + 20;
                }
            }

            if (txtHematocrit.Text != "")
            {
                if (Convert.ToDouble(txtHematocrit.Text) < 30)
                {
                    PSI = PSI + 10;
                }
            }

            if (rdoFahrenheit.IsChecked == true)
            {
                double celsiusTemp = Math.Round(((Convert.ToDouble(txtTemperature.Text) - 32) * 5 / 9), 1);
                temp = celsiusTemp;

                if (celsiusTemp < 35 || celsiusTemp > 39.9)
                {
                    PSI = PSI + 15;
                }

            }


            if (rdoCelsius.IsChecked == true)
            {
                temp = Convert.ToDouble(txtTemperature.Text);

                if (Convert.ToDouble(txtTemperature.Text) < 35 || Convert.ToDouble(txtTemperature.Text) > 39.9)
                {

                    PSI = PSI + 15;
                }
            }


            if (rdoBUNmg.IsChecked == true)
            {
                BUN = Convert.ToDouble(txtBUN.Text);
                if (Convert.ToDouble(txtBUN.Text) >= 30)
                {
                    PSI = PSI + 20;
                }
            }

            if (rdoBUNmmol.IsChecked == true)
            {
                double Mmol = Math.Round(Convert.ToDouble(txtBUN.Text) * 18);
                BUN = Mmol;
                if (Mmol >= 30)
                {
                    PSI = PSI + 20;
                }
            }

            if (rdoGlucoseMg.IsChecked == true)
            {
                glucose = Convert.ToDouble(txtGlucose.Text);
                if (Convert.ToDouble(txtGlucose.Text) >= 250)
                {
                    PSI = PSI + 10;
                }
            }

            if (rdoGlucoseMmol.IsChecked == true)
            {
                double glucoseMmol = Math.Round(Convert.ToDouble(txtGlucose.Text) * 18);
                glucose = glucoseMmol;
                if (glucoseMmol >= 250)
                {
                    PSI = PSI + 10;
                }
            }

            if (rdoOxygenMmHg.IsChecked == true)
            {
                oxygenPressure = Convert.ToDouble(txtOxygenPressure.Text);

                if (Convert.ToDouble(txtOxygenPressure.Text) < 60)
                {
                    PSI = PSI + 10;
                }
            }

            if (rdoOxygenKPa.IsChecked == true)
            {
                double oxygenMmHg = Math.Round(Convert.ToDouble(txtOxygenPressure.Text) * 7.50062);
                oxygenPressure = oxygenMmHg;

                if (oxygenMmHg < 60)
                {
                    PSI = PSI + 10;
                }
            }

            if (PSI <= Convert.ToDouble(txtAge.Text))
            {
                MessageBox.Show("Risk Class: 1" + "\n"
                                + "Risk: Low" + "\n"
                                + "PSI Level is: " + PSI + "\n"
                                + "Admission Status: Out-patient");
            }

            if (PSI > Convert.ToDouble(txtAge.Text) && PSI <= 70)
            {
                MessageBox.Show("Risk Class: 2" + "\n"
                                + "Risk: LOW" + "\n"
                                + "PSI Level is: " + PSI + "\n"
                                + "Admission Status: Out-patient");
            }

            if (PSI > Convert.ToDouble(txtAge.Text) && PSI >= 71 && PSI <= 90)
            {
                MessageBox.Show("Risk Class: 3" + "\n"
                                + "Risk: LOW" + "\n"
                                + "PSI Level is: " + PSI + "\n"
                                + "Admission Status: Out-patient/Observation");
            }

            if (PSI > Convert.ToDouble(txtAge.Text) && PSI >= 91 && PSI <= 130)
            {
                MessageBox.Show("Risk Class: 4" + "\n"
                                + "Risk: MODERATE" + "\n"
                                + "PSI Level is: " + PSI + "\n"
                                + "Admission Status: In-patient");
            }

            if (PSI > Convert.ToDouble(txtAge.Text) && PSI > 130)
            {
                MessageBox.Show("Risk Class: 5" + "\n"
                                + "Risk: HIGH" + "\n"
                                + "PSI Level is: " + PSI + "\n"
                                + "Admission Status: In-patient(Check for Sepsis)");
            }

            String file = @"data.csv";
            var lines = File.ReadAllLines(file);

            using (StreamWriter sw = File.AppendText(file))
            {
                sw.WriteLine(lines.Length + 1 + ", " + sex + ", " 
                    + txtAge.Text + ", " 
                    + pleuralEffusion + ", " 
                    + txtRespRate.Text + ", " 
                    + liverDisease + ", " 
                    + heartFailure + ", " 
                    + cerebroDisease + ", " 
                    + renalDisease + ", " 
                    + alteredMentalStatus + ", " 
                    + neoplastic + ", " 
                    + txtBloodPressure.Text + ", " 
                    + temp.ToString() + ", " 
                    + txtPulse.Text + ", " 
                    + txtPH.Text + ", " 
                    + BUN + ", " 
                    + txtSodium.Text + ", " 
                    + glucose + ", " 
                    + txtHematocrit.Text + ", " 
                    + oxygenPressure + ", " 
                    + nursingHome); ;
            }

        }
    }
}
