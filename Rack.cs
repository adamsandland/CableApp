public class Rack{
    private List<Device> _myDevices;
    private string _number, _location;
    private int _maxDevices = 48;
    public Rack(List<Device> myDevices, string number, string location){
        _myDevices=myDevices;
        _number=number;
        _location=location;
    }
    public string CheckPortID(string value){
        foreach (var item in _myDevices)
        {
            string check = item.CheckPortID(value);
            string whatIReturn = null;
            if(check!=null){
                whatIReturn = $"###RACK###|||{_number}|||{_location}|||"+check;
            }
            return whatIReturn;
        }
        return null;
    }
    public string GetNumber(){ return _number;}
    public string GetLocation(){ return _location;}
    public List<Device> GetDevices(){ return _myDevices;}
}