﻿using System;
using System.Windows.Forms;
using MilitaryFaculty.KnowledgeTest.Presentation.Views;

namespace UITest
{
    public partial class LoginForm : Form, ILoginView
    {
        private readonly ApplicationContext _context;

        public LoginForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
            this.IsStartPoint = true;

            FormClosed += (sender, args) => Invoke(ContextDisposed);
            btnStudent.Click += (sender, args) => Invoke(LoginAsStudent);
            btnTeacher.Click += (sender, args) => Invoke(LoginAsTeacher);
        }

        public new void Show()
        {
            _context.MainForm = this;
            if (this.IsStartPoint)
            {
                Application.Run(_context);
            }
            else
            {
                ((Form)this).Show();
            }
        }

        public string Password { get { return tbxPassword.Text; } }
        public bool IsStartPoint { get; set; }

        public event Action LoginAsStudent;
        public event Action LoginAsTeacher;
        public event Action ContextDisposed;

        public void ShowMessage(string message, string caption)
        {
            MessageBox.Show(message, caption);
        }

        public void Invoke(Action action)
        {
            if (action != null)
            {
                action();
            }
        }
    }
}
