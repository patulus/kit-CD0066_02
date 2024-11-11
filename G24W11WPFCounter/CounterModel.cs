namespace G24W11WPFCounter;

class CounterModel
{
	private int _count = 0;

	public int Count
	{
		get => _count; // Lambda expression
		set { if (value >= 0) _count = value; }
	}

	// AddValue, SubValue 메서드를 만들어 ViewModel이나 Model에 비즈니스 로직을 추가할 수 있다.
	// 세율 계산은 Model에서, 이를 호출하는 것은 ViewModel에서 하도록 할 수 있음

}
