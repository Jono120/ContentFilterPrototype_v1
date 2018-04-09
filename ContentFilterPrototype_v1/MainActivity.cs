using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace ContentFilterPrototype_v1
{
    [Activity(Label = "ContentFilterPrototype_v1", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button signUp;
        private Button submitNewUser;
        private EditText txtUsername;
        private EditText txtEmail;
        private EditText txtPassword;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            signUp = FindViewById<Button>(Resource.Id.btnSignUp);
            submitNewUser = FindViewById<Button>(Resource.Id.btnSave);
            txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);

            signUp.Click += (object sender, EventArgs args) =>
            {
                FragmentTransaction transFrag = FragmentManager.BeginTransaction();
                OnSignUpEvent.SignUpDialog diagSignUp = new OnSignUpEvent.SignUpDialog();
                diagSignUp.Show(transFrag, "Fragment Dialog");
                diagSignUp.OnSignUpComplete += diagSignUp_onSignUpComplete;
            };
        }

        private void diagSignUp_onSignUpComplete(object sender, OnSignUpEvent e)
        {
            StartActivity(typeof(Activity));
        }
        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);

        //    // Set our view from the "main" layout resource
        //    SetContentView(Resource.Layout.Main);
        //    Button button = FindViewById<Button>(Resource.Id.btnButton);
        //    button.Click += delegate
        //    {
        //        button.Text = "Hello world I am your first App!";

        //    };
        //}
    }
}

