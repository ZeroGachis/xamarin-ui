﻿using System;
using System.Globalization;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smartway.UiComponent.FormsElements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormEntry
    {
        public enum EntryTypes
        {
            Input,
            Select
        }

        public static readonly Color LightGrayColor = Color.FromHex("#E2E4F0");
        public static readonly Color GrayColor = Color.FromHex("#B2B2B2");

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(FormEntry), string.Empty);

        public static readonly BindableProperty PrefixProperty =
            BindableProperty.Create(nameof(Prefix), typeof(string), typeof(FormEntry), string.Empty);

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(FormEntry), string.Empty);

        public static readonly BindableProperty PlaceHolderProperty =
            BindableProperty.Create(nameof(PlaceHolder), typeof(string), typeof(FormEntry), string.Empty);

        public static readonly BindableProperty HelperProperty =
            BindableProperty.Create(nameof(Helper), typeof(string), typeof(FormEntry), string.Empty);

        public static readonly BindableProperty ReadOnlyProperty =
            BindableProperty.Create(nameof(ReadOnly), typeof(bool), typeof(FormEntry));

        public static readonly BindableProperty DisabledProperty = BindableProperty.Create(nameof(Disabled),
            typeof(bool), typeof(FormEntry), propertyChanged: DisabledMode);

        public static readonly BindableProperty ErrorProperty =
            BindableProperty.Create(nameof(Error), typeof(bool), typeof(FormEntry));

        public static readonly BindableProperty EntryTypeProperty =
            BindableProperty.Create(nameof(EntryType), typeof(EntryTypes), typeof(FormEntry), EntryTypes.Input, propertyChanged: OnEntryTypeChanged);

        private static void OnEntryTypeChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var entryType = (EntryTypes) newvalue;
            var formElement = (FormEntry) bindable;

            switch (entryType)
            {
                case EntryTypes.Input:
                    formElement.EntryArrow.IsVisible = false;
                    break;

                case EntryTypes.Select:
                    formElement.EntryArrow.IsVisible = true;
                    break;
            }
        }

        public string Title
        {
            get => (string) GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Prefix
        {
            get => (string) GetValue(PrefixProperty);
            set => SetValue(PrefixProperty, value);
        }

        public string Text
        {
            get => (string) GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public string PlaceHolder
        {
            get => (string) GetValue(PlaceHolderProperty);
            set => SetValue(PlaceHolderProperty, value);
        }

        public string Helper
        {
            get => (string) GetValue(HelperProperty);
            set => SetValue(HelperProperty, value);
        }

        public bool Error
        {
            get => (bool) GetValue(ErrorProperty);
            set => SetValue(ErrorProperty, value);
        }

        public bool ReadOnly
        {
            get => (bool) GetValue(ReadOnlyProperty);
            set => SetValue(ReadOnlyProperty, value);
        }

        public bool Disabled
        {
            get => (bool) GetValue(DisabledProperty);
            set => SetValue(DisabledProperty, value);
        }

        public EntryTypes EntryType
        {
            get => (EntryTypes) GetValue(EntryTypeProperty);
            set => SetValue(EntryTypeProperty, value);
        }

        public FormEntry()
        {
            InitializeComponent();
        }

        private void InputOnFocused(object sender, FocusEventArgs e)
        {
            EntryDividerPrefix.BackgroundColor = Color.Black;
            EntryDividerInput.BackgroundColor = Color.Black;
            EntryDividerArrow.BackgroundColor = Color.Black;
        }

        private void InputOnUnfocused(object sender, FocusEventArgs e)
        {
            EntryDividerPrefix.BackgroundColor = LightGrayColor;
            EntryDividerInput.BackgroundColor = LightGrayColor;
            EntryDividerArrow.BackgroundColor = LightGrayColor;
        }

        private static void DisabledMode(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bool) newValue)
            {
                var formElement = (FormEntry) bindable;
                var grayColor = GrayColor;

                formElement.EntryTitle.TextColor = grayColor;
                formElement.EntryPrefix.TextColor = grayColor;
                formElement.EntryHelper.TextColor = grayColor;
                formElement.CustomEntry.TextColor = grayColor;

                formElement.CustomEntry.IsEnabled = false;
                formElement.EntryArrow.IsVisible = false;
            }
        }
    }
}