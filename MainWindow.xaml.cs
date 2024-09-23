using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Samy_Djemai_CALCULETTE
{
    public partial class MainWindow : Window
    {
        // Variables pour stocker les valeurs et l'opération en cours
        private double valeurActuelle = 0;
        private double valeurStockée = 0;  
        private string operation = "";     
        private bool _isOperationClicked = false; 

        public MainWindow()
        {
            InitializeComponent();
            TB_Display.Text = "0"; // Initialise l'affichage de la calculatrice avec 0
        }

        
        private void Bouton_Chiffre_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button; // declaration variable type Button 
            if (button != null)
            {
               
                if (_isOperationClicked || TB_Display.Text == "0")
                {
                    TB_Display.Text = button.Content.ToString(); 
                    _isOperationClicked = false; // Réinitialise l'indicateur d'opération
                }
                else
                {
                    // Sinon, on ajoute le chiffre cliqué à l'affichage
                    TB_Display.Text += button.Content.ToString();
                }
            }
        }


        
        private void Bouton_Plus_Click(object sender, RoutedEventArgs e)
        {
            // Fonction qui Stocke la valeur actuelle avant de faire une addition
            StoreCurrentValue();
            operation = "+"; 
        }

        private void Bouton_Moins_Click(object sender, RoutedEventArgs e)
        {
            StoreCurrentValue(); 
            operation = "-"; 
        }

        private void Bouton_Fois_Click(object sender, RoutedEventArgs e)
        {
            StoreCurrentValue(); 
            operation = "*"; 
        }

        private void Bouton_Divise_Click(object sender, RoutedEventArgs e)
        {
            StoreCurrentValue(); 
            operation = "/"; 
        }

        // méthode qui gere l'evenement bouton egal
        private void Bouton_Egal_Click_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(operation)) // Si une opération est définie
            {
                double newValue = double.Parse(TB_Display.Text); // Convertit l'affichage en nombre
                double result = 0; 

                // Exécute l'opération choisie
                switch (operation)
                {
                    case "+":
                        result = valeurStockée + newValue; 
                        break;
                    case "-":
                        result = valeurStockée - newValue; 
                        break;
                    case "*":
                        result = valeurStockée * newValue; 
                        break;
                    case "/":
                        if (newValue != 0) 
                        {
                            result = valeurStockée / newValue; 
                        }
                        else
                        {
                            MessageBox.Show("Division par zéro n'est pas autorisée."); 
                            return;
                        }
                        break;
                }

                TB_Display.Text = result.ToString(); 
                operation = string.Empty; 
                _isOperationClicked = true; 
            }
        }

      
        private void Bouton_Clear_Click(object sender, RoutedEventArgs e)
        {
            TB_Display.Text = "0"; 
            valeurStockée = 0; 
            operation = ""; 
            _isOperationClicked = false; 
        }

        
        private void StoreCurrentValue()
        {
            valeurStockée = double.Parse(TB_Display.Text); 
            _isOperationClicked = true; 
        }

        
        private void TB_Display_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text); // Bloque les caractères non numériques
        }

        // Vérifie que le texte entré est un chiffre ou un point
        private static bool IsTextAllowed(string text)
        {
            foreach (char c in text)
            {
                // Retourne false si un caractère n'est pas un chiffre ou un point
                if (!Char.IsDigit(c) && c != '.')
                {
                    return false;
                }
            }
            return true;
        }

        private void Bouton_pi_Click(object sender, RoutedEventArgs e)
        {
            TB_Display.Text = "3,141592"; 
            _isOperationClicked = false; 
        }


        private void Bouton_carre_Click(object sender, RoutedEventArgs e)
        {
            double currentValue = double.Parse(TB_Display.Text); 
            double result = currentValue * currentValue; 
            TB_Display.Text = result.ToString(); 
            _isOperationClicked = false; 
        }


        private void Bouton_exposant_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Bouton_virg_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
