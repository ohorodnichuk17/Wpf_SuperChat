using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_SuperChat.Core;
using Wpf_SuperChat.MVVM.Model;

namespace Wpf_SuperChat.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        public RelayCommand SendCommand { get; set; }

        private ContactModel selectedContact;

        public ContactModel SelectedContact
        {
            get => selectedContact; 
            set
            {
                selectedContact = value; 
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get => _message; 
            set
            { 
                _message = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });

                Message = "";
            });

            Messages.Add(new MessageModel
            {
                Username = "Allison",
                UsernameColor = "#409AFF",
                ImageSource = "./Images/man1.jpg",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            Messages.Add(new MessageModel
            {
                Username = "Julia",
                UsernameColor = "#409AFF",
                ImageSource = "./Images/woman1.jpg",
                Message = "Hello, how are you?",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });


            Messages.Add(new MessageModel
            {
                Username = "Sara",
                UsernameColor = "#409AFF",
                ImageSource = "./Images/woman2.jpg",
                Message = "Hi, what`s up?",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Allison",
                    UsernameColor = "#409AFF",
                    ImageSource = "./Images/man1.jpg",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false
                });
            }

            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Bunny",
                    UsernameColor = "#409AFF",
                    ImageSource = "./Images/man1.jpg",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = true,
                });
            }

            Messages.Add(new MessageModel
            {
                Username = "Bunny",
                UsernameColor = "#409AFF",
                ImageSource = "./Images/man1.jpg",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeOrigin = true,
            });

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"Allison {i}",
                    ImageSource = "./Images/man2.png",
                    Messages = Messages
                });
            }

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"Julia {i}",
                    ImageSource = "./Images/woman1.jpg",
                    Messages = Messages
                });
            }
        }

    }
}
