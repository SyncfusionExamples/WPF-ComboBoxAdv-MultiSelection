# WPF ComboBoxAdv MultiSelection
This repository demonstrates how to select items programmatically in the Syncfusion WPF ComboBoxAdv control and enable multi-selection functionality.

## Why Use ComboBoxAdv MultiSelection?
- Allows users to select multiple items from a dropdown list.
- Supports data binding for dynamic item updates.
- Ideal for scenarios like filtering, tagging, or multi-choice forms.

## Creating project
Follow these steps to create a new WPF project in Visual Studio and add the ComboBoxAdv control:

### Adding Control Manually in XAML

1. Add the required assembly reference:
   - Syncfusion.Shared.WPF

2. Import the Syncfusion WPF schema:
```XAML
xmlns:syncfusion="http://schemas.syncfusion.com/wpf"
```

3. Declare the ComboBoxAdv in XAML:
```XAML
<Grid>
    <syncfusion:ComboBoxAdv Height="30" Width="150"/>
</Grid>
```

### Adding Control Manually in C#

1. Add the required assembly reference:
   - Syncfusion.Shared.WPF

2. Import the namespace:
```C#
using Syncfusion.Windows.Tools.Controls;
```

3. Create and configure the ComboBoxAdv instance:
```C#
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ComboBoxAdv comboBoxAdv = new ComboBoxAdv
        {
            Height = 30,
            Width = 150,
            DefaultText = "Choose Items"
        };
        this.Content = comboBoxAdv;
    }
}
```
## ComboBoxAdv MultiSelection Example
Enable multi-selection and bind data using MVVM:

**[XAML]**
```XAML
<Window.DataContext>
    <local:ViewModel />
</Window.DataContext>

<Grid>
    <syncfusion:ComboBoxAdv DisplayMemberPath="Name"
                             SelectedItems="{Binding SelectedItems, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                             AllowMultiSelect="True"
                             Name="comboboxadv"
                             HorizontalAlignment="Center"
                             Height="30"
                             VerticalAlignment="Center"
                             Width="150"
                             ItemsSource="{Binding Countries}"/>
</Grid>
```
**ViewModel**
```C#
public class ViewModel : INotifyPropertyChanged
{
    private ObservableCollection<object> selectedItems;
    public ObservableCollection<object> SelectedItems
    {
        get => selectedItems;
        set
        {
            selectedItems = value;
            RaisePropertyChanged(nameof(SelectedItems));
        }
    }

    public ObservableCollection<Country> Countries { get; set; }

    public ViewModel()
    {
        Countries = new ObservableCollection<Country>
        {
            new Country() { Name = "Denmark" },
            new Country() { Name = "New Zealand" },
            new Country() { Name = "Canada" },
            new Country() { Name = "Russia" },
            new Country() { Name = "Japan" }
        };

        SelectedItems = new ObservableCollection<object>(Countries.Take(2));
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void RaisePropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public class Country
{
    public string Name { get; set; }
}
```
