using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calculapapus
{
    public partial class MainWindow : Window
    {
        private string modoActual = "decimal"; // Modo por defecto
        double valorActual = 0;
        double valorAnterior = 0;
        string operacionActual = "";
        bool nuevaOperacion = false;



        public MainWindow()
        {
            InitializeComponent();
            BotonA.IsEnabled = false;
            BotonB.IsEnabled = false;
            BotonC.IsEnabled = false;
            BotonD.IsEnabled = false;
            BotonE.IsEnabled = false;
            BotonF.IsEnabled = false;

            ChangeButtonColor(BotonA, Brushes.Red);
            ChangeButtonColor(BotonB, Brushes.Red);
            ChangeButtonColor(BotonC, Brushes.Red);
            ChangeButtonColor(BotonD, Brushes.Red);
            ChangeButtonColor(BotonE, Brushes.Red);
            ChangeButtonColor(BotonF, Brushes.Red);

        }

        private void BotonNumero_Click(object sender, RoutedEventArgs e)
        {
            if (nuevaOperacion)
            {
                Pantalla.Text = "0";
                nuevaOperacion = false;
            }

            Button boton = sender as Button;
            if (Pantalla.Text == "0")
            {
                Pantalla.Text = boton.Content.ToString();
            }
            else
            {
                Pantalla.Text += boton.Content.ToString();
            }
        }

        private void BotonClearEntry_Click(object sender, RoutedEventArgs e)
        {
            Pantalla.Text = "0";
        }

        private void BotonClear_Click(object sender, RoutedEventArgs e)
        {
            Pantalla.Text = "0";
            valorAnterior = 0;
            valorActual = 0;
            operacionActual = "";
        }

        private void BotonBorrarUltimo_Click(object sender, RoutedEventArgs e)
        {
            if (Pantalla.Text.Length > 1)
            {
                Pantalla.Text = Pantalla.Text.Substring(0, Pantalla.Text.Length - 1);
            }
            else
            {
                Pantalla.Text = "0";
            }
        }

        private void BotonPunto_Click(object sender, RoutedEventArgs e)
        {
            if (!Pantalla.Text.Contains("."))
            {
                Pantalla.Text += ".";
            }
        }

        private void BotonIgual_Click(object sender, RoutedEventArgs e)
        {
            valorActual = ConvertToDouble(Pantalla.Text);

            switch (operacionActual)
            {
                case "+":
                    valorActual = valorAnterior + valorActual;
                    break;
                case "-":
                    valorActual = valorAnterior - valorActual;
                    break;
                case "x":
                    valorActual = valorAnterior * valorActual;
                    break;
                case "÷":
                    if (valorActual != 0)
                    {
                        valorActual = valorAnterior / valorActual;
                    }
                    else
                    {
                        MessageBox.Show("Error: División por 0");
                    }
                    break;
            }

            Pantalla.Text = ConvertToMode(valorActual);
            nuevaOperacion = true;
        }

        private void BotonPorcentaje_Click(object sender, RoutedEventArgs e)
        {
            double valor = ConvertToDouble(Pantalla.Text);
            valor /= 100;
            Pantalla.Text = valor.ToString(CultureInfo.InvariantCulture);
        }

        private void BotonInverso_Click(object sender, RoutedEventArgs e)
        {
            double valor = ConvertToDouble(Pantalla.Text);
            if (valor != 0)
            {
                valor = 1 / valor;
                Pantalla.Text = valor.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                MessageBox.Show("Error: División por cero.");
            }
        }

        private void BotonCuadrado_Click(object sender, RoutedEventArgs e)
        {
            double valor = ConvertToDouble(Pantalla.Text);
            valor = Math.Pow(valor, 2);
            Pantalla.Text = valor.ToString(CultureInfo.InvariantCulture);
        }

        private void BotonRaizCuadrada_Click(object sender, RoutedEventArgs e)
        {
            double valor = ConvertToDouble(Pantalla.Text);
            valor = Math.Sqrt(valor);
            Pantalla.Text = valor.ToString(CultureInfo.InvariantCulture);
        }

        private void BotonOperacion_Click(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            operacionActual = boton.Content.ToString();
            valorAnterior = ConvertToDouble(Pantalla.Text);
            nuevaOperacion = true;
        }

        private void BotonBinario_Click(object sender, RoutedEventArgs e)
        {
            modoActual = "binario";
            Pantalla.Text = "0";
            ChangeColors(Brushes.Gray, Brushes.Green);

            // Deshabilitar los botones del 2 al 9
            Boton2.IsEnabled = false;
            Boton3.IsEnabled = false;
            Boton4.IsEnabled = false;
            Boton5.IsEnabled = false;
            Boton6.IsEnabled = false;
            Boton7.IsEnabled = false;
            Boton8.IsEnabled = false;
            Boton9.IsEnabled = false;

            BotonA.IsEnabled = false;
            BotonB.IsEnabled = false;
            BotonC.IsEnabled = false;
            BotonD.IsEnabled = false;
            BotonE.IsEnabled = false;
            BotonF.IsEnabled = false;

            // Deshabilitar operaciones matemáticas especiales
            BotonInverso.IsEnabled = false;
            BotonCuadrado.IsEnabled = false;
            BotonRaizCuadrada.IsEnabled = false;
            BotonPorcentaje.IsEnabled = false;

            // Cambiar color a rojo para los botones deshabilitados
            ChangeButtonColor(Boton2, Brushes.Red);
            ChangeButtonColor(Boton3, Brushes.Red);
            ChangeButtonColor(Boton4, Brushes.Red);
            ChangeButtonColor(Boton5, Brushes.Red);
            ChangeButtonColor(Boton6, Brushes.Red);
            ChangeButtonColor(Boton7, Brushes.Red);
            ChangeButtonColor(Boton8, Brushes.Red);
            ChangeButtonColor(Boton9, Brushes.Red);
            ChangeButtonColor(BotonA, Brushes.Red);
            ChangeButtonColor(BotonB, Brushes.Red);
            ChangeButtonColor(BotonC, Brushes.Red);
            ChangeButtonColor(BotonD, Brushes.Red);
            ChangeButtonColor(BotonE, Brushes.Red);
            ChangeButtonColor(BotonF, Brushes.Red);
            ChangeButtonColor(BotonInverso, Brushes.Red);
            ChangeButtonColor(BotonCuadrado, Brushes.Red);
            ChangeButtonColor(BotonRaizCuadrada, Brushes.Red);
            ChangeButtonColor(BotonPorcentaje, Brushes.Red);
        }

        private void BotonHexadecimal_Click(object sender, RoutedEventArgs e)
        {
            modoActual = "hexadecimal";
            Pantalla.Text = "0";
            ChangeColors(Brushes.Gray, Brushes.Blue);

            // Habilitar todos los botones numéricos del 0 al 9
            Boton2.IsEnabled = true;
            Boton3.IsEnabled = true;
            Boton4.IsEnabled = true;
            Boton5.IsEnabled = true;
            Boton6.IsEnabled = true;
            Boton7.IsEnabled = true;
            Boton8.IsEnabled = true;
            Boton9.IsEnabled = true;
            BotonA.IsEnabled = true;
            BotonB.IsEnabled = true;
            BotonC.IsEnabled = true;
            BotonD.IsEnabled = true;
            BotonE.IsEnabled = true;
            BotonF.IsEnabled = true;

            // Deshabilitar operaciones matemáticas especiales
            BotonInverso.IsEnabled = false;
            BotonCuadrado.IsEnabled = false;
            BotonRaizCuadrada.IsEnabled = false;
            BotonPorcentaje.IsEnabled = false;

            // Cambiar color a azul para los botones habilitados, rojo para los deshabilitados
            ChangeButtonColor(Boton2, Brushes.Blue);
            ChangeButtonColor(Boton3, Brushes.Blue);
            ChangeButtonColor(Boton4, Brushes.Blue);
            ChangeButtonColor(Boton5, Brushes.Blue);
            ChangeButtonColor(Boton6, Brushes.Blue);
            ChangeButtonColor(Boton7, Brushes.Blue);
            ChangeButtonColor(Boton8, Brushes.Blue);
            ChangeButtonColor(Boton9, Brushes.Blue);
            ChangeButtonColor(BotonInverso, Brushes.Red);
            ChangeButtonColor(BotonCuadrado, Brushes.Red);
            ChangeButtonColor(BotonRaizCuadrada, Brushes.Red);
            ChangeButtonColor(BotonPorcentaje, Brushes.Red);
        }

        private void BotonDecimal_Click(object sender, RoutedEventArgs e)
        {
            modoActual = "decimal";
            Pantalla.Text = "0";
            ChangeColors(Brushes.White, Brushes.Black);

            // Habilitar todos los botones
            Boton2.IsEnabled = true;
            Boton3.IsEnabled = true;
            Boton4.IsEnabled = true;
            Boton5.IsEnabled = true;
            Boton6.IsEnabled = true;
            Boton7.IsEnabled = true;
            Boton8.IsEnabled = true;
            Boton9.IsEnabled = true;
            BotonInverso.IsEnabled = true;
            BotonCuadrado.IsEnabled = true;
            BotonRaizCuadrada.IsEnabled = true;
            BotonPorcentaje.IsEnabled = true;

            BotonA.IsEnabled = false;
            BotonB.IsEnabled = false;
            BotonC.IsEnabled = false;
            BotonD.IsEnabled = false;
            BotonE.IsEnabled = false;

            // Cambiar color de los botones habilitados a negro
            ChangeButtonColor(Boton2, Brushes.Black);
            ChangeButtonColor(Boton3, Brushes.Black);
            ChangeButtonColor(Boton4, Brushes.Black);
            ChangeButtonColor(Boton5, Brushes.Black);
            ChangeButtonColor(Boton6, Brushes.Black);
            ChangeButtonColor(Boton7, Brushes.Black);
            ChangeButtonColor(Boton8, Brushes.Black);
            ChangeButtonColor(Boton9, Brushes.Black);
            ChangeButtonColor(BotonA, Brushes.Red);
            ChangeButtonColor(BotonB, Brushes.Red);
            ChangeButtonColor(BotonC, Brushes.Red);
            ChangeButtonColor(BotonD, Brushes.Red);
            ChangeButtonColor(BotonE, Brushes.Red);
            ChangeButtonColor(BotonF, Brushes.Red);
            ChangeButtonColor(BotonInverso, Brushes.Black);
            ChangeButtonColor(BotonCuadrado, Brushes.Black);
            ChangeButtonColor(BotonRaizCuadrada, Brushes.Black);
            ChangeButtonColor(BotonPorcentaje, Brushes.Black);
        }

        private void ChangeColors(Brush background, Brush buttonForeground)
        {
            MainGrid.Background = background;

            foreach (Button button in BotonGrid.Children)
            {
                button.Foreground = buttonForeground;
            }
        }

        private void ChangeButtonColor(Button button, Brush color)
        {
            button.Foreground = color;
        }

        private double ConvertToDouble(string value)
        {
            if (modoActual == "binario")
            {
                return Convert.ToInt32(value, 2);
            }
            if (modoActual == "hexadecimal")
            {
                return Convert.ToInt32(value, 16);
            }
            return double.Parse(value, CultureInfo.InvariantCulture);
        }

        private string ConvertToMode(double value)
        {
            if (modoActual == "binario")
            {
                return Convert.ToString((int)value, 2);
            }
            if (modoActual == "hexadecimal")
            {
                return Convert.ToString((int)value, 16).ToUpper();
            }
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}