using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RmemBR.Core.Views.Controls
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class FloatingEntry : ContentView
  {
    #region BindableProperties

    public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string),
      typeof(FloatingEntry), defaultBindingMode: BindingMode.TwoWay);

    public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string),
      typeof(FloatingEntry), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
      {
        var matEntry = (FloatingEntry)bindable;
        matEntry.EntryField.Placeholder = (string)newval;
        matEntry.HiddenLabel.Text = (string)newval;
      });

    public static BindableProperty ClearOnFocusProperty = BindableProperty.Create(nameof(ClearOnfocus), typeof(bool),
 typeof(FloatingEntry), defaultValue: false);

    public static BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool),
  typeof(FloatingEntry), defaultValue: false, propertyChanged: (bindable, oldVal, newVal) =>
  {
    var matEntry = (FloatingEntry)bindable;
    matEntry.EntryField.IsPassword = (bool)newVal;
  });

    public static BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard),
      typeof(FloatingEntry), defaultValue: Keyboard.Default, propertyChanged: (bindable, oldVal, newVal) =>
      {
        var matEntry = (FloatingEntry)bindable;
        matEntry.EntryField.Keyboard = (Keyboard)newVal;
      });

    public static BindableProperty ReturnCommandProperty = BindableProperty.Create(nameof(ReturnCommmand), typeof(ICommand), typeof(FloatingEntry)
      , propertyChanged: (bindable, oldVal, newVal) =>
      {
        var matEntry = (FloatingEntry)bindable;
        matEntry.EntryField.ReturnCommand = (ICommand)newVal;
      });

    public static BindableProperty CommandProperty = BindableProperty.Create(nameof(ReturnCommmand), typeof(ICommand), typeof(FloatingEntry)
  , propertyChanged: (bindable, oldVal, newVal) =>
  {
    var matEntry = (FloatingEntry)bindable;
    matEntry.EntryField.ReturnCommand = (ICommand)newVal;
  });

    public bool TopLabelVisible = false;

    #endregion BindableProperties

    public bool ClearOnfocus
    {
      get { return (bool)GetValue(ClearOnFocusProperty); }
      set { SetValue(ClearOnFocusProperty, value); }
    }

    public ICommand ReturnCommmand
    {
      get { return (ICommand)GetValue(ReturnCommandProperty); }
      set { SetValue(ReturnCommandProperty, value); }
    }

    public Keyboard Keyboard
    {
      get { return (Keyboard)GetValue(KeyboardProperty); }
      set { SetValue(KeyboardProperty, value); }
    }

    public bool IsPassword
    {
      get { return (bool)GetValue(IsPasswordProperty); }
      set { SetValue(IsPasswordProperty, value); }
    }

    public string Text
    {
      get { return (string)GetValue(TextProperty); }
      set { SetValue(TextProperty, value); }
    }

    public string Placeholder
    {
      get { return (string)GetValue(PlaceholderProperty); }
      set { SetValue(PlaceholderProperty, value); }
    }
    private string _placeHolderValue { get; set; }

    public FloatingEntry()
    {
      InitializeComponent();
      EntryField.BindingContext = this;
      EntryField.Focused     += OnEntryFieldOnFocused;
      EntryField.TextChanged += EntryFieldOnTextChanged;
      EntryField.Unfocused   += EntryField_Unfocused;
    }


    private void EntryField_Unfocused(object sender, FocusEventArgs e)
    {
      if (string.IsNullOrEmpty(EntryField.Text))
      {
        EntryField.Placeholder = _placeHolderValue;
        HiddenLabel.IsVisible = false;
      }
    }

    private void EntryFieldOnTextChanged(object sender, TextChangedEventArgs e)
    {
      if (string.IsNullOrEmpty(EntryField.Text))
      {
        EntryField.Placeholder = _placeHolderValue;
        HiddenLabel.IsVisible = false;
      }
      else
        HiddenLabel.IsVisible = true;
    }

    private void OnEntryFieldOnFocused(object s, FocusEventArgs a)
    {
      HiddenLabel.IsVisible = true;

      if (!string.IsNullOrEmpty(EntryField.Placeholder))
      {
        _placeHolderValue = EntryField.Placeholder;
      }

      if (ClearOnfocus)
      {
        EntryField.Text = "";
      }

      EntryField.Placeholder = "";
    }
  };
}
