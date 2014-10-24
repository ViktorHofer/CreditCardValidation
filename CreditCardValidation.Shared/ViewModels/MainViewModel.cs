using CreditCardValidation.Validators;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidation.Common.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly CreditCardNumberValidator _creditCardNumberValidator;
        private readonly INavigationService _navigationService;

        public RelayCommand<string> AcceptCreditCardNumberCommand { get; private set; }

        public MainViewModel(INavigationService navigationService,
            CreditCardNumberValidator creditCardNumberValidator)
        {
            _navigationService = navigationService;
            _creditCardNumberValidator = creditCardNumberValidator;

            AcceptCreditCardNumberCommand = new RelayCommand<string>(onAcceptCreditCardNumberExecuted, onAcceptCreditCardNumberCanExecute);
        }

        private void onAcceptCreditCardNumberExecuted(string creditCardNumber)
        {
            _navigationService.NavigateTo(ViewModelLocator)
        }

        private bool onAcceptCreditCardNumberCanExecute(string creditCardNumber)
        {
            return _creditCardNumberValidator.Validate(creditCardNumber).IsValid;
        }
    }
}
