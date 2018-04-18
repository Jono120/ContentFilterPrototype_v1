using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace ContentFilterPrototype_v1
{
    [Activity(Label = "ContentFilterPrototype_v1", MainLauncher = true)]
    public class MainActivity : Activity
    {
        //This creates the main classes and text boxes into the application for the user.
        //NOTE: These are currently not working properly.
        private Button signUp;
        private Button submitNewUser;
        private EditText txtUsername;
        private EditText txtEmail;
        private EditText txtPassword;


        //This is class that will create the buttons and create the layouts for the input text boxes.
        //This allows the user to click into one of the text boxes and input a username and a password.
        protected override void OnCreate(Bundle bundle)
        {
            //NOTE: The buttons and text boxes are not getting input because something is not linking them to the above calling.
            //They are also not being referenced in the Resources code.
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

        //This is bouncing the information through a second Activity document to allow for the application to run in the background.
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

