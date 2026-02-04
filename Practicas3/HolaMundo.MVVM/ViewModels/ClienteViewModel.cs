using HolaMundo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace HolaMundo.MVVM.ViewModels
{
    public class ClienteViewModel : INotifyPropertyChanged
    {
        private ClienteModel cliente;
        public ClienteModel Cliente
        {
            get { return cliente; }
            set { cliente = value; OnPropertyChanged();}
        }

        private string mensaje;
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; OnPropertyChanged(); }
        }

        public ICommand Command { get; set; }

        public ClienteViewModel()
        {
            cliente = new ClienteModel();
            Command = new Command(Guardar);
        }

        public void Guardar()
        {
            Mensaje = $"Hola {Cliente.Nombre} {Cliente.Apellidos}";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
