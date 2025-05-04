using BusinessLogicLayer.BLL;
using DataTransferObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class FremmoedeRegistrering : Window
    {
        private string valgtHoldNavn = null;
        private DataTransferObject.Model.Hold valgtHold = new DataTransferObject.Model.Hold();
        private List<Springer> holdetSpringere = new List<Springer>();
        private List<DataTransferObject.Model.Hold> alleHold = new List<DataTransferObject.Model.Hold>();
        private List<DataTransferObject.Model.Fremmoederegistrering> alleFremmoederegistreringer = new List<Fremmoederegistrering>();
        private HoldBLL holdbll;
        private FremmoederegistreringBLL FremmoederegistreringBLL;
        private TraeningBLL traeningBLL;
        public FremmoedeRegistrering()
        {
            InitializeComponent();

            FremmoederegistreringBLL = new FremmoederegistreringBLL();
            holdbll = new HoldBLL();
            traeningBLL = new TraeningBLL();

            alleHold = holdbll.GetAllHold().ToList();
            AlleHoldPanel.DataContext = alleHold;
            PlayerStackPanel.DataContext = holdetSpringere;

            alleHold.ForEach(Hold =>
            {
                RadioButton holdBTN = new RadioButton
                {
                    Content = Hold.HoldNavn
                };

                holdBTN.Checked += RadioButton_Checked;
                AlleHoldPanel.Children.Add(holdBTN);
            });
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            PlayerStackPanel.Children.Clear();

            if (sender is RadioButton radioButton)
            {
                valgtHoldNavn = radioButton.Content.ToString();
                
            }

            valgtHold = alleHold.First(hold => hold.HoldNavn == valgtHoldNavn);
            holdetSpringere = valgtHold.Springere;

            holdetSpringere.ForEach(springer =>
            {
                var stackPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(0, 5, 0, 5)
                };

                var playerName = new Label
                {
                    Content = springer.Navn,
                    VerticalAlignment = VerticalAlignment.Center
                };

                var statusBTN = new Button
                {
                    Content = "SYG",
                    Tag = springer,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(10, 0, 0, 0)
                };

                statusBTN.Click += StatusBTN_Click;

                stackPanel.Children.Add(playerName);
                stackPanel.Children.Add(statusBTN);
                PlayerStackPanel.Children.Add(stackPanel);
            });
        }

        private void StatusBTN_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            switch (button.Content.ToString())
            {
                case "SYG":
                    button.Content = "FRAVÆRENDE";
                    break;
                case "FRAVÆRENDE":
                    button.Content = "FREMMØDT";
                    break;
                default:
                    button.Content = "SYG";
                    break;
            }
        }

        private void RegistrerFremmoede(object sender, RoutedEventArgs e)
        {
            if (!DatoVælger.SelectedDate.HasValue)
            {
                MessageBox.Show("Vælg venligst en dato.");
                return;
            }

            DateTime valgtDato = DatoVælger.SelectedDate.Value;

            foreach (StackPanel stack in PlayerStackPanel.Children)
            {
                var button = stack.Children.OfType<Button>().FirstOrDefault();
                var springer = button?.Tag as Springer;

                if (springer != null)
                {
                    Status status;

                    switch (button.Content.ToString())
                    {
                        case "FREMMØDT":
                            status = Status.FREMMOEDT;
                            break;
                        case "FRAVÆRENDE":
                            status = Status.FRAVAERENDE;
                            break;
                        case "SYG":
                        default:
                            status = Status.SYG;
                            break;
                    }

                    Fremmoederegistrering fremmoede = new Fremmoederegistrering
                    {
                        Springer = springer,
                        MoedeStatus = status
                    };

                    FremmoederegistreringBLL.AddFremmoederegistrering(fremmoede);
                    alleFremmoederegistreringer.Add(fremmoede);
                    

                }
            }
            Traening newTraening = new Traening(valgtDato, valgtHold, alleFremmoederegistreringer);
            traeningBLL.AddTraening(newTraening);

            MessageBox.Show("Fremmøde registreret.");
        }
    }
}
