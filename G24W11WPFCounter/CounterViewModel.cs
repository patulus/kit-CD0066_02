using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace G24W11WPFCounter;

class CounterViewModel : INotifyPropertyChanged
{
    private CounterModel _model;

    public CounterViewModel()
    {
        _model = new CounterModel();
    }

    // View인 XAML의 TextBox와 ViewModel의 Value를 연결
    public int Value
    {
        get => _model.Count;
        set
        {
            _model.Count = value;
            OnPropertyChanged();
            // 어떤 프로퍼티가 변경됐는지 알려주기 위해 OnPropertyChanged("Value")를 사용해야 하지만,
            // 귀찮고 헷갈릴 우려가 있어 [CallerMemberName]을 파라미터에 사용하면 프로퍼티 이름이 자동으로 인자가 됨
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    // CallerMemberName 애트리뷰트는 호출한 함수 이름
    // 프로퍼티 이름인 "Value"를 argument로 넘겨줌
    protected void OnPropertyChanged([CallerMemberName] string propName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
