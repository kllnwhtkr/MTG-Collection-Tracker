﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KW.WinFormsUI.Docking;
using CustomControls;

namespace MTG_Librarian
{
    public partial class TasksForm : DockContent
    {
        public TaskManager TaskManager { get; private set; }

        public TasksForm()
        {
            InitializeComponent();
            tasksListView.BackColor = Color.Transparent;
        }

        public void InitializeTaskManager()
        {
            TaskManager = new TaskManager(Globals.Forms.MainForm.TasksLabel, Globals.Forms.MainForm.TasksProgressBar);
        }
    }
}
