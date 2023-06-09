﻿using App_Clinica.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App_Clinica.ViewModels
{
    public class LoginViewModel:ViewModelBase
    {
        private string _userName;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible;

        private UserRepository userRepository;

        // Variaveis de Classe
        public string UserName { get => _userName; set { _userName = value; OnPropertyChanged(nameof(UserName)); } }
        public SecureString Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }


        //Comandos
        public ICommand LoginCommand { get;}
        public ICommand RecoverPasswordCommand { get;}
        public ICommand ShowPasswordCommand { get;}
        public ICommand RememberPasswordCommand { get;}

        public LoginViewModel()
        {
            userRepository = new UserRepository();

            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);

            RecoverPasswordCommand = new ViewModelCommand(ExecuteRecoverPassCommand);
        }

        private void ExecuteRecoverPassCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(UserName) || UserName.Length<3 || Password == null || Password.Length < 3)
                validData = false;
                
            else 
                validData = true;

            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new System.Net.NetworkCredential(UserName, Password));

            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(UserName),null);

                IsViewVisible = false;
            }
            else
            {
                IsViewVisible = true;
                ErrorMessage = "Usuário ou Senha Inválida";
            }
        }
    }
}
