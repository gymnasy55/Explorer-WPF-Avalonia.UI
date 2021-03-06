﻿using System;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Styling;

namespace Polcraz.GoogleChromeWindow.AvaloniaUI
{
    #nullable enable
    public class GoogleChromeWindow : Window, IStyleable
    {
        #region Private Fields

        private const string PartTitleBar = "PART_TitleBar";

        private Grid? _titleBar;

        #endregion

        #region IStyleable

        Type IStyleable.StyleKey => typeof(GoogleChromeWindow);

        #endregion

        #region Dependency Properties

        public static readonly StyledProperty<ICommand> CloseCommandProperty =
            AvaloniaProperty.Register<GoogleChromeWindow, ICommand>(
                nameof(CloseCommand));

        public static readonly StyledProperty<ICommand> ExpandCommandProperty =
            AvaloniaProperty.Register<GoogleChromeWindow, ICommand>(
                nameof(ExpandCommand));

        public static readonly StyledProperty<ICommand> CollapseCommandProperty =
            AvaloniaProperty.Register<GoogleChromeWindow, ICommand>(
                nameof(CollapseCommand));

        public static readonly StyledProperty<object> ToolBarContentProperty =
            AvaloniaProperty.Register<GoogleChromeWindow, object>(nameof(ToolBarContent));

        #endregion

        #region Public Properties

        public ICommand CollapseCommand
        {
            get => GetValue(CollapseCommandProperty);
            set => SetValue(CollapseCommandProperty, value);
        }

        public ICommand ExpandCommand
        {
            get => GetValue(ExpandCommandProperty);
            set => SetValue(ExpandCommandProperty, value);
        }

        public ICommand CloseCommand
        {
            get => GetValue(CloseCommandProperty);
            set => SetValue(CloseCommandProperty, value);
        }


        public object ToolBarContent
        {
            get => GetValue(ToolBarContentProperty);
            set => SetValue(ToolBarContentProperty, value);
        }

        #endregion

        #region Constructor

        public GoogleChromeWindow()
        {
            CloseCommand = new DelegateCommand(OnClose);
            CollapseCommand = new DelegateCommand(OnCollapse);
            ExpandCommand = new DelegateCommand(OnExpand);

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        #endregion

        #region Protected Methods

        protected override void OnTemplateApplied(TemplateAppliedEventArgs e)
        {
            base.OnTemplateApplied(e);

            _titleBar = e.NameScope.Get<Grid>(PartTitleBar);
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);

            if (Equals(e.Source, _titleBar))
            {
                BeginMoveDrag(e);
            }
        }

        #endregion

        #region Private Methods

        private void OnClose(object obj)
        {
            Close();
        }

        private void OnCollapse(object obj)
        {
            WindowState = WindowState.Minimized;
        }

        private void OnExpand(object obj)
        {
            WindowState = WindowState switch
            {
                WindowState.Normal => WindowState.Maximized,
                WindowState.Maximized => WindowState.Normal,
                _ => WindowState
            };
        }

        #endregion
    }
}