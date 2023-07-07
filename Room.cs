public class Room{
    private List<Rack> _myRacks;
    private string _RoomName, _RoomLocation;
    public Room(List<Rack> myRacks, string RoomName, string RoomLocation){
        _myRacks=myRacks;
        _RoomName=RoomName;
        _RoomLocation=RoomLocation;
    }
    public string CheckPortID(string value){
        foreach (var item in _myRacks)
        {
            string check = item.CheckPortID(value);
            string whatIReturn = null;
            if(check!=null){
                whatIReturn = $"###ROOM###|||{_RoomName}|||{_RoomLocation}|||"+check;
            }
            return whatIReturn;
        }
        return null;
    }
    public string GetName(){ return _RoomName;}
    public string GetLocation(){ return _RoomLocation;}
    public List<Rack> GetRacks(){ return _myRacks;}
}