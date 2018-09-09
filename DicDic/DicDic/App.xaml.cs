﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using F = System.Windows.Forms;
namespace DicDic
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ShutdownMode = ShutdownMode.OnExplicitShutdown;
            MainWindow = new MainWindow();
            MainWindow.Show();
            MainWindow.Hide();
            CreateNotifyIcon();
        }

        private F.MenuItem _miHotkey;

        private void CreateNotifyIcon()
        {
            var ni = new F.NotifyIcon()
            {
                Text = "DicDic",
                Visible = true,
                Icon = DicDic.Properties.Resources.NotifyIcon,
                ContextMenu = new F.ContextMenu(new[] {
                    _miHotkey=new F.MenuItem("启用全局快捷键"),
                    new F.MenuItem("搜索引擎",new []{
                        new F.MenuItem("谷歌"){ RadioCheck=true,Checked=true},
                        new F.MenuItem("百度"){ RadioCheck=true},
                        new F.MenuItem("必应"){ RadioCheck=true},
                    }),
                    new F.MenuItem("-"),
                    new F.MenuItem("帮助",(s,args)=>{
                        Shutdown();
                    }),
                    new F.MenuItem("关于",(s,args)=>{
                        Shutdown();
                    }),
                    new F.MenuItem("-"),
                    new F.MenuItem("退出",(s,args)=>{
                        Shutdown();
                    })
                })
            };

            ni.Click += (s, args) =>
            {
                MainWindow.Show();
                MainWindow.Activate();
            };
        }
    }
}
