using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ContentFilterPrototype_v1
{
    public class OnSignUpEvent : EventArgs
    {
        private string txtUserName;
        private string txtEmail;
        private string txtPassword;

        public string UserName
        {
            get { return txtUserName; }
            set
            {
                txtUserName = value;
            }
        }

        public string Email
        {
            get { return txtEmail; }
            set { txtEmail = value; }
        }

        public string Password
        {
            get { return txtPassword; }
            set { txtPassword = value; }
        }

        public OnSignUpEvent(string username, string email, string password, string txtUserName, string txtEmail, string txtPassword) : base()
        {
            //this.txtUserName = txtUserName;
            //this.txtEmail = txtEmail;
            //this.txtPassword = txtPassword;
            UserName = username;
            Email = email;
            Password = password;
        }

        public class SignUpDialog : DialogFragment
        {
            private EditText txtUsername;
            private EditText txtEmail;
            private EditText txtPassword;
            private Button btnSaveSignUp;
            public event EventHandler<OnSignUpEvent> OnSignUpComplete;
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreateView(inflater, container, savedInstanceState);
                var view = inflater.Inflate(Resource.Layout.registerDialog, container, false);
                txtUserame = view.FindViewById<EditText>(Resource.Id.txtUserName);
                txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
                txtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
                btnSaveSignUp = view.FindViewById<Button>(Resource.Id.btnSave);
                btnSaveSignUp.Click += btnSaveSignUp_Click;
                return view;
            }
            void btnSaveSignUp_Click(object sender, EventArgs e)
            {
                OnSignUpComplete.Invoke(this, new OnSignUpEvent(txtUsername.Text, txtEmail.Text, txtPassword.Text));
                this.Dismiss();
            }
        }
    }
}
